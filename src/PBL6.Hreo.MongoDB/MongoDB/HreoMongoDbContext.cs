using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace PBL6.Hreo.MongoDB
{
    [ConnectionStringName(HreoDbProperties.ConnectionStringName)]
    public class HreoMongoDbContext : AbpMongoDbContext, IHreoMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureHreo();
        }
    }
}