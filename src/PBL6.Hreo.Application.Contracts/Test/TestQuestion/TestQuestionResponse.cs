using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Models
{
    public class TestQuestionResponse : FullAuditedEntityDto<Guid>
    {
        public int OrderIndex { get; set; }

        public string Content { get; set; }

        public string Answers { get; set; }

        public int Result { get; set; }
    }
}
