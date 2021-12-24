using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class ApplicantTest : CreationAuditedEntity<Guid>
    {
        public Guid ApplicantId { get; set; }

        public Guid PostId { get; set; }

        public Guid TestId { get; set; }

        public double Result { get; set; }

        public Post Post { get; set; }

        public Test Test { get; set; }

        [ForeignKey("ApplicantId")]
        public UserInformation Applicant { get; set; }

        public List<ApplicantTestQuestion> ApplicantTestQuestions { get; set; }
    }
}
