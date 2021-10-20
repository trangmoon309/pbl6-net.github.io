using System;
using FileService;
using Microsoft.EntityFrameworkCore;
using PBL6.Hreo.Entities;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace PBL6.Hreo.EntityFrameworkCore
{
    public static class HreoDbContextModelCreatingExtensions
    {
        public static void ConfigureHreo(
            this ModelBuilder builder,
            Action<HreoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HreoModelBuilderConfigurationOptions(
                HreoDbProperties.DbTablePrefix,
                HreoDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<TestQuestion>(b =>
            {
                b.ToTable(options.TablePrefix + "TestQuestions", "test");
                b.ConfigureByConvention();
            });

            builder.Entity<Test>(b =>
            {
                b.ToTable(options.TablePrefix + "Tests", "test");
                b.ConfigureByConvention();
            });

            builder.Entity<InterestedPost>(b =>
            {
                b.ToTable("InterestedPosts", "post");
                b.ConfigureByConvention();
            });

            builder.Entity<InvitationPost>(b =>
            {
                b.ToTable("InvitationPosts", "post");
                b.ConfigureByConvention();
            });

            builder.Entity<ApplicantPost>(b =>
            {
                b.ToTable("ApplicantPosts", "post");
                b.ConfigureByConvention();
            });

            builder.Entity<Post>(b =>
            {
                b.ToTable("Posts", "post");
                b.ConfigureByConvention();
            });

            builder.Entity<Company>(b =>
            {
                b.ToTable("Companies", "company");
                b.ConfigureByConvention();
            });

            builder.Entity<CompanyReview>(b =>
            {
                b.ToTable("CompanyReviews", "company");
                b.ConfigureByConvention();
            });

            builder.Entity<Branch>(b =>
            {
                b.ToTable("Branches", "company");
                b.ConfigureByConvention();
            });

            builder.Entity<UserInformation>(b =>
            {
                b.ToTable("UserInformations", "user");
                b.ConfigureByConvention();
            });

            builder.Entity<FileInformation>(b =>
            {
                b.ToTable("FileInformations", "file");
                b.ConfigureByConvention();
            });
        }
    }
}