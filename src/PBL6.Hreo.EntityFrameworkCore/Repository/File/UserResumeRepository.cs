using PBL6.Hreo.Entities;
using PBL6.Hreo.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FileService.FileRepository
{
    public class UserResumeRepository : EfCoreRepository<IHreoDbContext, UserResume, Guid>, IUserResumeRepository
    {
        public UserResumeRepository(IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}