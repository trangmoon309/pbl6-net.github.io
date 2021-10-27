using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class Test : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public Language Language { get; set; }

        public Level Level { get; set; }

        public TimeSpan LimitTime { get; set; }

        public List<TestQuestion> TestQuestions {get; set;}
    }
}
