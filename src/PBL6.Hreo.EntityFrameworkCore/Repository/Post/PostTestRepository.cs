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
    public class PostTestRepository : EfCoreRepository<IHreoDbContext, PostTest, Guid>, IPostTestRepository
    {
        public PostTestRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<PostTest> GetList()
        {
            return GetQueryable().Where(x => !x.IsDeleted)
                .Include(x => x.Post)
                .Include(x => x.Test);
        }

        public async Task<PostTest> GetById(Guid id)
        {
            var query = await GetQueryable().Where(x => !x.IsDeleted && x.Id.Equals(id))
                .Include(x => x.Post)
                .Include(x => x.Test)
                .FirstOrDefaultAsync();
            return query;
        }

        public void DeleteByPostId(Guid postId)
        {
            var query = GetQueryable().Where(x => !x.IsDeleted && x.PostId.Equals(postId));
            DbContext.PostTests.RemoveRange(query);
        }
    }
}
