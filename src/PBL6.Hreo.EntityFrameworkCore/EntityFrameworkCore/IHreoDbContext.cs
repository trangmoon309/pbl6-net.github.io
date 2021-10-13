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
    }
}