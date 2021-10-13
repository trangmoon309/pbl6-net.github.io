using System;
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
        }
    }
}