using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class NotificationUserResponse : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public UserResponse User { get; set; }
    }
}
