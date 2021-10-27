using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class TestWithQuestionResponse : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public bool Status { get; set; }

        public string Language { get; set; }

        public string Level { get; set; }

        public TimeSpan LimitTime { get; set; }

        public List<TestQuestionResponse> TestQuestions { get; set; } 
    }
}
