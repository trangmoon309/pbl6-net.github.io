using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Models
{
    public class BranchResponse : FullAuditedEntityDto<Guid>
    {
        public string City { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }

        public CompanyResponse Company { get; set; }
    }
}
