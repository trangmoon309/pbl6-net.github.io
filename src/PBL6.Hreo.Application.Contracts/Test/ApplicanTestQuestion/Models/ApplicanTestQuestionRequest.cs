using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class ApplicanTestQuestionRequest
    {
        public Guid ApplicantId { get; set; }

        public Guid PostId { get; set; }

        public Guid TestId { get; set; }

        public Guid TestQuestionId { get; set; }

        public int Choose { get; set; }
    }
}
