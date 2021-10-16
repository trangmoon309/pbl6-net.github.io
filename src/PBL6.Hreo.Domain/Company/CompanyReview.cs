using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class CompanyReview : FullAuditedAggregateRoot<Guid>
    {
        public Guid CompanyId { get; set; }

        public Guid ApplicationId { get; set; }

        public string Content { get; set; }

        public int Rate { get; set; }

        public Company Company { get; set; }

        [ForeignKey("ApplicantId")]
        public UserInformation Application { get; set; }
    }
}
