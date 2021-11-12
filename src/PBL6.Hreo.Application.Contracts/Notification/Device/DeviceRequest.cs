using System;
using System.Collections.Generic;
using System.Text;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class DeviceRequest
    {
        public string DeviceToken { get; set; }

        public Guid UserId { get; set; }

        public string DeviceType { get; set; }
    }
}
