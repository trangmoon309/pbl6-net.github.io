using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class InvitationPostRequest
    {
        public Guid PostId { get; set; }

        public Guid ApplicantId { get; set; }

        public InvitationPostStatus InvitationPostStatus { get; set; }
    }

    public class InvitationPostRequest2
    {
        public Guid PostId { get; set; }

        public List<Guid> ApplicantIds { get; set; }
    }
}
