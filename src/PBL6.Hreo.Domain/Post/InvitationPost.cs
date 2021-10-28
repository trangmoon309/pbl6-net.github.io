using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class InvitationPost : FullAuditedAggregateRoot<Guid>
    {
        public Guid PostId { get; set; }

        public Guid ApplicantId { get; set; }

        public InvitationPostStatus InvitationPostStatus { get; set; }

        public Post Post { get; set; }

        [ForeignKey("ApplicationId")]
        public UserInformation UserInformation { get; set; }
    }
}
