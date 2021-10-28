using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class SendTestToApplicationRequest
    {
        public Guid PostId { get; set; }

        public Guid TestId { get; set; }

        public Guid ApplicantId { get; set; }
    }
}
