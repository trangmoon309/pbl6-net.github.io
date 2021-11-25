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
using Volo.Abp.Domain.Repositories;
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

        public DeviceAppService(IDeviceRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
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
    }
}
