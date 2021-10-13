using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace PBL6.Hreo.MongoDB
{
    public static class HreoMongoDbContextExtensions
    {
        public static void ConfigureHreo(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HreoMongoModelBuilderConfigurationOptions(
                HreoDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}