using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class Branch : FullAuditedAggregateRoot<Guid>
    {
        public string City { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }

        public Guid CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
