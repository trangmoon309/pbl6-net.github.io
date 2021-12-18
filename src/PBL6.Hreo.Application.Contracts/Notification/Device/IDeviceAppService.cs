using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Services
{
    public interface IDeviceAppService : ICrudAppService<
                DeviceResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                DeviceRequest,
                DeviceRequest>
    {
        Task SeedDevice(string deviceToken);
    }
}
