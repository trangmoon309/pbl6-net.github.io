using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL6.Hreo.Entities
{
    public class Device : FullAuditedAggregateRoot<Guid>
    {
        public string DeviceToken { get; set; }

        public Guid UserId { get; set; }

        public string DeviceType { get; set; }
    }
}
