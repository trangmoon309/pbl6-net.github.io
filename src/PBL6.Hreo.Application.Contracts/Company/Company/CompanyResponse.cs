using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Models
{
    public class CompanyResponse : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }
    }
}
