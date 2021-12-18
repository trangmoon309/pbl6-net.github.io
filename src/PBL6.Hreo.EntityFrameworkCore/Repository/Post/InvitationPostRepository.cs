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
    public class InvitationPostRepository : EfCoreRepository<IHreoDbContext, InvitationPost, Guid>, IInvitationPostRepository
    {
        public InvitationPostRepository(Volo.Abp.EntityFrameworkCore.IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public IQueryable<InvitationPost> GetList()
        {
            return GetQueryable().Where(x => !x.IsDeleted)
                .Include(x => x.Post)
                .Include(x => x.Applicant);
        }

        public async Task<InvitationPost> GetById(Guid id)
        {
            var query = await GetQueryable().Where(x => !x.IsDeleted && x.Id.Equals(id))
                 .Include(x => x.Post)
                .FirstOrDefaultAsync();
            return query;
        }

        public async Task CreateMultiple(List<InvitationPost> invitationPosts)
        {
            await DbContext.InvitationPosts.AddRangeAsync(invitationPosts);
        }

    }
}
