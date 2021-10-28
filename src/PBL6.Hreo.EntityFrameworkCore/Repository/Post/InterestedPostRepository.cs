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
    public class InterestedPostRepository : EfCoreRepository<IHreoDbContext, InterestedPost, Guid>, IInterestedPostRepository
    {
        public InterestedPostRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<InterestedPost> GetList()
        {
            return GetQueryable().Where(x => !x.IsDeleted)
                .Include(x => x.Post);
        }

        public async Task<InterestedPost> GetById(Guid id)
        {
            var query = await GetQueryable().Where(x => !x.IsDeleted && x.Id.Equals(id))
                 .Include(x => x.Post)
                .FirstOrDefaultAsync();
            return query;
        }

        public IQueryable<InterestedPost> GetByPostId(Guid postId)
        {
            var query = GetQueryable().Where(x => !x.IsDeleted && x.PostId.Equals(postId))
                 .Include(x => x.Post);
            return query;
        }
    }
}
