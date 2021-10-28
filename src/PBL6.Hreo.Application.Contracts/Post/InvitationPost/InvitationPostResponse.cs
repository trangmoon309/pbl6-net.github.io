using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class InvitationPostResponse : FullAuditedEntityDto<Guid>
    {
        public PostResponse Post { get; set; }

        public UserInformationResponse Applicant { get; set; }

        public Guid PostId { get; set; }

        public Guid ApplicantId { get; set; }

        public InvitationPostStatus InvitationPostStatus { get; set; }

    }
}
