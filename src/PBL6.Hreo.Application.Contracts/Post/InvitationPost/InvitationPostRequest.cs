using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Post.InvitationPost
{
    public class InvitationPostRequest
    {
        public Guid PostID { get; set; }

        public Guid ApplicantID { get; set; }

        public Guid CreatorID { get; set; }

        public InvitationPostStatus InvitationPostStatus { get; set; }

        public DateTime SentTime { get; set; }

        public DateTime LastModifiedTime { get; set; }
    }
}
