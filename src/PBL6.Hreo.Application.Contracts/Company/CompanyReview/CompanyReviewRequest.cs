using System;
using System.Collections.Generic;
using System.Text;

namespace PBL6.Hreo.Models
{
    public class CompanyReviewRequest
    {
        public Guid CompanyId { get; set; }

        public Guid ApplicationId { get; set; }

        public string Content { get; set; }

        public int Rate { get; set; }
    }
}
