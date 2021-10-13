using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL6.Hreo.Entities
{
    public class TestQuestion : FullAuditedAggregateRoot<Guid>
    {
        public int OrderIndex { get; set; }

        public string Content { get; set; }

        public string Answers { get; set; }

        public int Result { get; set; }
    }
}
