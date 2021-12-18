using System;
using System.Collections.Generic;
using System.Text;

namespace PBL6.Hreo.Models
{
    public class PushNotificationRequest
    {
        public string to { get; set; }

        public string title { get; set; }

        public string subtitle { get; set; }

        public string body { get; set; }
    }
}
