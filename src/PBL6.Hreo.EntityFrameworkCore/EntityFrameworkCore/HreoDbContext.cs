using FileService;
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

        public DbSet<Test> Tests { get; set; }

        public DbSet<InterestedPost> InterestedPosts { get; set; }

        public DbSet<InvitationPost> InvitationPosts { get; set; }

        public DbSet<ApplicantPost> ApplicantPosts { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyReview> CompanyReviews { get; set; }

        public DbSet<UserInformation> UserInformations { get; set; }

        public DbSet<FileInformation> FileImformations { get; set; }

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