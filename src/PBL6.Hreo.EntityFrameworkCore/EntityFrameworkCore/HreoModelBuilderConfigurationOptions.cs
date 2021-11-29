using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace PBL6.Hreo.EntityFrameworkCore
{
    public class HreoModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public HreoModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {
        }
    }
}