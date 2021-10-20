using System;
using System.Collections.Generic;
using System.Text;

namespace PBL6.Hreo.Models
{
    public class BranchRequest
    {
        public string City { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }

        public Guid CompanyId { get; set; }
    }
}
