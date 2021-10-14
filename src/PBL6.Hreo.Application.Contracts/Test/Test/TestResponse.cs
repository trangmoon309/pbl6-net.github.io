using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class TestResponse : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public Language Language { get; set; }

        public Level Level { get; set; }

        public TimeSpan LimitTime { get; set; }
    }
}
