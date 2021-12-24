using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class ApplicantPostRequest
    {
        public Guid PostId { get; set; }

        public Guid ApplicantId { get; set; }

        public ApplicantPostStatus ApplicantPostStatus { get; set; }

        public string ApplicantAnswer { get; set; }

        public float TestResult { get; set; }

        public DateTime StartTime { get; set; }

        public float TimeUsed { get; set; }

        public float TimeFinished { get; set; }
    }
}
