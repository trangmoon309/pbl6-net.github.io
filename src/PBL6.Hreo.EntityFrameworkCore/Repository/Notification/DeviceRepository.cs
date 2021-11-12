using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using PBL6.Hreo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;

namespace PBL6.Hreo.Repository
{
    public class DeviceRepository : EfCoreRepository<IHreoDbContext, Device, Guid>, IDeviceRepository
    {
        public DeviceRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<Device> GetList()
        {
            return GetQueryable().Where(x => !x.IsDeleted);
        }
    }
}
