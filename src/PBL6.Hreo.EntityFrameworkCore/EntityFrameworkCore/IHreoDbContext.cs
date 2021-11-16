using FileService;
using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace PBL6.Hreo.EntityFrameworkCore
{
    [ConnectionStringName(HreoDbProperties.ConnectionStringName)]
    public interface IHreoDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */

        public DbSet<TestQuestion> TestQuestions { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<InterestedPost> InterestedPosts { get; set; }

        public DbSet<InvitationPost> InvitationPosts { get; set; }

        public DbSet<ApplicantPost> ApplicantPosts { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<CompanyReview> CompanyReviews { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<UserInformation> UserInformations { get; set; }

        public DbSet<FileInformation> FileImformations { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<NotificationUser> NotificationUsers { get; set; }

        public DbSet<UserResume> UserResumes { get; set; }
    }
}