using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Models
{
    public class CompanyReviewResponse : FullAuditedEntityDto<Guid>
    {
        public string Content { get; set; }

        public int Rate { get; set; }

        public CompanyResponse Company { get; set; }

        public UserInformationResponse Application { get; set; }
    }
}
