using Newtonsoft.Json;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                string json = JsonConvert.SerializeObject(request.FirstOrDefault());

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

        public async Task<string> SendEmailNotification(string title)
        {
            try
            {
                //Converting the object to a json string. NOTE: Make sure the object doesn't contain circular references.
                var listReceiver = new List<SendEmailRequest>();

                listReceiver.Add(new SendEmailRequest
                {
                    subject = title,
                    email = "huynhphuongtrang309@gmail.com"
                });

                listReceiver.Add(new SendEmailRequest
                {
                    subject = title,
                    email = "khanhquynh133@gmail.com"
                });

                listReceiver.Add(new SendEmailRequest
                {
                    subject = title,
                    email = "yua2307@gmail.com"
                });

                listReceiver.Add(new SendEmailRequest
                {
                    subject = title,
                    email = "nhatnguyen522000@gmail.com"
                });

                listReceiver.Add(new SendEmailRequest
                {
                    subject = title,
                    email = "nguyenngochuyena8@gmail.com"
                });

                foreach (var item in listReceiver)
                {
                    string json = JsonConvert.SerializeObject(item);

                    //Needed to setup the body of the request
                    StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                    //The url to post to.
                    var url = "https://pbl6nodejs.azurewebsites.net/api/mailing";
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJSUzI1NiIsImtpZCI6IkE5REMzOTY0RDBGMzZFRjE3MTIxNTFGQUM3OTU0ODQ2IiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2Mzk4NDU5NzYsImV4cCI6MTY3MTM4MTk3NiwiaXNzIjoiaHR0cDovLzIwLjg1LjIzNC4xMDk6MTExMiIsImF1ZCI6IkhyZW8iLCJjbGllbnRfaWQiOiJIcmVvX0FwcCIsInN1YiI6IjNhMDBjNmEzLThmMDAtODExNC1jMmIwLWU0YmMzNzIyNzcxYSIsImF1dGhfdGltZSI6MTYzOTg0NTk3NiwiaWRwIjoibG9jYWwiLCJyb2xlIjoiYWRtaW4iLCJwaG9uZV9udW1iZXJfdmVyaWZpZWQiOiJGYWxzZSIsImVtYWlsIjoiYWRtaW5AYWJwLmlvIiwiZW1haWxfdmVyaWZpZWQiOiJGYWxzZSIsIm5hbWUiOiJhZG1pbiIsImlhdCI6MTYzOTg0NTk3Niwic2NvcGUiOlsiSHJlbyJdLCJhbXIiOlsicHdkIl19.sRT_D25ItFfl-CsRUSYHT9Z33sAOraHJpGtqLiJMqxkv4bvPtdAh2COtwov_Tdn5Sz9lY0wKv6dr2W98Bkttfj3MSrbTCkRqpMnTcyQKLqadQKlo0RKF37oxPZiy6TzealROT1FXSKpkuZ8rCRLPLN93xgkibaT_54HJfFt0aO2osPxbovNuPCQmjXeZzYz4F3CouwZKWPY7L0c4FBcY7cP9KAntH1l7mog4Dkwic5C2AbfOWxSPJzjM11fkrq2-cbuw6KtjuR-JpcswBwVh13U-fsJtQahR2ywjeT3DuxDIjNXDE9mGF4OzrsMQJEmUo-znWIj-39KvXLnvOyjtOg");
                    //Pass in the full URL and the json string content
                    var response = await client.PostAsync(url, data);

                    //It would be better to make sure this request actually made it through
                    string result = await response.Content.ReadAsStringAsync();

                    //close out the client
                    client.Dispose();
                }
                
                return "Ok";

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
