using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class DeviceResponse : FullAuditedEntityDto<Guid>
    {
        public string DeviceToken { get; set; }

        public Guid UserId { get; set; }

        public string DeviceType { get; set; }

        public UserResponse User { get; set; }
    }
}
