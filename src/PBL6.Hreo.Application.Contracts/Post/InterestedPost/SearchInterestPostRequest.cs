using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class SearchInterestPostRequest
    {
        public InterestedPostStatus? Status { get; set; }

        public string KeyWord { get; set; }
    }
}
