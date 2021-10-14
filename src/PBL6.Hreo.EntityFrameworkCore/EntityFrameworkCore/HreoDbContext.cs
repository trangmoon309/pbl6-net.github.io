using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.EntityFrameworkCore
{
    [ConnectionStringName(HreoDbProperties.ConnectionStringName)]
    public class HreoDbContext : AbpDbContext<HreoDbContext>, IHreoDbContext
    {
        public DbSet<TestQuestion> TestQuestions { get; set; }

        public DbSet<Post> Tests { get; set; }

        public DbSet<InterestedPost> InterestedPosts { get; set; }

        public DbSet<InvitationPost> InvitationPosts { get; set; }

        public DbSet<ApplicantPost> ApplicantPosts { get; set; }

        public DbSet<Post> Posts { get; set; }

        public HreoDbContext(DbContextOptions<HreoDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureHreo();
        }
    }
}