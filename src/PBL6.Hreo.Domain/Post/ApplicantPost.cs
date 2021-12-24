using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class ApplicantPost : FullAuditedAggregateRoot<Guid>
    {
        public Guid PostId { get; set; }

        public Guid ApplicantId { get; set; }

        public ApplicantPostStatus ApplicantPostStatus { get; set; }

        public string ApplicantAnswer { get; set;}

        public float TestResult { get; set; }

        public DateTime StartTime { get; set; }

        public float TimeUsed { get; set; }

        public float TimeFinished { get; set; }

        public Post Post { get; set; }

        [ForeignKey("ApplicationId")]
        public UserInformation UserInformation { get; set; }
    }
}
