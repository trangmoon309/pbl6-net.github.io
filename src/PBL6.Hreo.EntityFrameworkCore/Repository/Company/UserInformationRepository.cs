using PBL6.Hreo.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.Repository
{
    public class UserInformationRepository : EfCoreRepository<IHreoDbContext, UserInformation, Guid>, IUserInformationRepository
    {
        public UserInformationRepository(IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
