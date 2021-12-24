using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class ApplicantPostResponse : FullAuditedEntityDto<Guid>
    {
        public PostResponse Post { get; set; }

        public UserInformationResponse UserInformation { get; set; }

        public string ApplicantPostStatus { get; set; }

        public string ApplicantAnswer { get; set; }

        public float TestResult { get; set; }

        public DateTime StartTime { get; set; }

        public float TimeUsed { get; set; }

        public float TimeFinished { get; set; }
    }
}
