using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class PostTestResponse : FullAuditedEntityDto<Guid>
    {
        public Guid PostId { get; set; }

        public Guid TestId { get; set; }

        public TestResponse Test { get; set; }
    }
}
