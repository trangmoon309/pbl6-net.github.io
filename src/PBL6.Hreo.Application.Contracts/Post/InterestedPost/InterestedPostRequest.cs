using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class InterestedPostRequest
    {
        public Guid PostID { get; set; }

        public Guid ApplicantID { get; set; }

        public InterestedPostStatus InterestedPostStatus { get; set; }

        public DateTime SentTime { get; set; }

    }
}
