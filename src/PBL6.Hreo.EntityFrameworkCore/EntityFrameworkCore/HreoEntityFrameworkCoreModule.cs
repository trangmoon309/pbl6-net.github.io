using FileService;
using FileService.FileRepository;
using Microsoft.Extensions.DependencyInjection;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Repository;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PBL6.Hreo.EntityFrameworkCore
{
    [DependsOn(
        typeof(HreoDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule)
    )]
    public class HreoEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HreoIdentityDbContext>(options =>
            {
                options.AddRepository<User, UserRepository>();
                options.AddRepository<UserRole, UserRoleRepository>();
            });

            context.Services.AddAbpDbContext<HreoDbContext>(options =>
            {
                options.AddRepository<Branch, BranchRepository>();
                options.AddRepository<Company, CompanyRepository>();
                options.AddRepository<CompanyReview, CompanyReviewRepository>();
                options.AddRepository<UserInformation, UserInformationRepository>();

                options.AddRepository<Test, TestRepository>();
                options.AddRepository<TestQuestion, TestQuestionRepository>();

                options.AddRepository<Post, PostRepository>();
                options.AddRepository<ApplicantPost, ApplicantPostRepository>();
                options.AddRepository<InvitationPost, InvitationPostRepository>();
                options.AddRepository<InterestedPost, InterestedPostRepository>();

                options.AddRepository<FileInformation, FileInformationRepository>();

                options.AddRepository<Device, DeviceRepository>();
                options.AddRepository<NotificationUser, NotificationUserRepository>();

                options.AddRepository<UserResume, UserResumeRepository>();

            });
        }
    }
}