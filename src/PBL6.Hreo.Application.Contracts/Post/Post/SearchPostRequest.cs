using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class SearchPostRequest
    {
        public PostStatus? Status { get; set; }

        public string KeyWord { get; set; }

        public bool? IsHidden { get; set; }

        public Guid? ApplicantId { get; set; }
    }
}
