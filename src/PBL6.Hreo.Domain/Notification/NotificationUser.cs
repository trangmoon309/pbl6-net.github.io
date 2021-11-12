using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace PBL6.Hreo.Entities
{
    public class NotificationUser : FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
