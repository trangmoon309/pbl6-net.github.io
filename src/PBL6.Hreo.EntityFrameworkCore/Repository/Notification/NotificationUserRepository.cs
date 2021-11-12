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
    public class NotificationUserRepository : EfCoreRepository<IHreoDbContext, NotificationUser, Guid>, INotificationUserRepository
    {
        public NotificationUserRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<NotificationUser> GetList()
        {
            return GetQueryable().Where(x => !x.IsDeleted);
        }
    }
}
