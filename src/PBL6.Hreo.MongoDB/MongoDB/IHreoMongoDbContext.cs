using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace PBL6.Hreo.MongoDB
{
    [ConnectionStringName(HreoDbProperties.ConnectionStringName)]
    public interface IHreoMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
