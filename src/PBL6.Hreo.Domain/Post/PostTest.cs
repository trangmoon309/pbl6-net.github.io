using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL6.Hreo.Entities
{
    public class PostTest : FullAuditedAggregateRoot<Guid>
    {
        public Guid PostId { get; set; }

        public Guid TestId { get; set; }

        public Post Post { get; set; }

        public Test Test { get; set; }
    }
}
