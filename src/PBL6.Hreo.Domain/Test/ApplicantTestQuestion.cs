using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class ApplicantTestQuestion : CreationAuditedEntity<Guid>
    {
        public Guid ApplicantTestId {get; set;}

        public Guid TestQuestionId { get; set; }

        public int Choose { get; set; }

        public TestQuestion TestQuestion { get; set; }

        public ApplicantTest ApplicantTest { get; set; }
    }
}
