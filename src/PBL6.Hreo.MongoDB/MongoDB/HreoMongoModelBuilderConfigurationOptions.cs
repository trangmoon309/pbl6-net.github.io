using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace PBL6.Hreo.MongoDB
{
    public class HreoMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public HreoMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}