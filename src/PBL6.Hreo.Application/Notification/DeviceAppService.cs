using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Linq;

namespace PBL6.Hreo.Services
{
    public class DeviceAppService : CrudAppService<
            Device,
            DeviceResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            DeviceRequest,
            DeviceRequest>,
        IDeviceAppService
    {
        private readonly IDeviceRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        protected IIdentityUserRepository _userRepository { get; }

        public DeviceAppService(IDeviceRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter, 
            IIdentityUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _userRepository = userRepository;
        }

        public override async Task<DeviceResponse> CreateAsync(DeviceRequest input)
        {
            try
            {
                var deviceByUser = _repository.GetByUser(input.UserId);

                if(deviceByUser != null)
                {
                    var toList = await _asyncQueryableExecuter.ToListAsync(deviceByUser);
                    var existToken = toList.FirstOrDefault(x => x.DeviceToken.Equals(input.DeviceToken));

                    if (existToken == null)
                    {
                        return await base.CreateAsync(input);
                    }

                    else return null;
                }
                else
                {
                    return await base.CreateAsync(input);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task SeedDevice(string deviceToken)
        {
            try
            {
                var users = await _userRepository.GetListAsync();
                var userInfors = await _repository.GetListAsync();
                var addedEntity = new List<Device>();

                foreach (var item in users)
                {
                    if (userInfors.FirstOrDefault(x => x.UserId == item.Id) == null)
                    {
                        var createdUserInfor = new Device
                        {
                            UserId = item.Id,
                            DeviceToken = deviceToken,
                            DeviceType = "Iphone"
                        };

                        EntityHelper.TrySetId(createdUserInfor, GuidGenerator.Create);
                        addedEntity.Add(createdUserInfor);
                    }
                }

                await _repository.InsertManyAsync(addedEntity);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
