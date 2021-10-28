using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class SearchAppTestRequest
    {
        public ApplicantPostStatus? ApplicantPostStatus { get; set; }

        public string KeyWord { get; set; }
    }
}
