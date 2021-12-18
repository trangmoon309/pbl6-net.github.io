using Newtonsoft.Json;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace PBL6.Hreo.Services
{
    public class NotificationUserAppService : CrudAppService<
            NotificationUser,
            NotificationUserResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            NotificationUserRequest,
            NotificationUserRequest>,
        INotificationUserAppService
    {
        private readonly INotificationUserRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;

        public NotificationUserAppService(INotificationUserRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
        }

        public async Task<string> SendNotification(List<PushNotificationRequest> request)
        {
            try
            {
                //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
                string json = JsonConvert.SerializeObject(request);

                //Needed to setup the body of the request
                StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                //The url to post to.
                var url = "https://api.expo.dev/v2/push/send";
                var client = new HttpClient();

                //Pass in the full URL and the json string content
                var response = await client.PostAsync(url, data);

                //It would be better to make sure this request actually made it through
                string result = await response.Content.ReadAsStringAsync();

                //close out the client
                client.Dispose();

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
