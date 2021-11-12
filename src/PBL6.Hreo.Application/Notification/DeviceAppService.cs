using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
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
    }
}
