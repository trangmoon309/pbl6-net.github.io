using System;
using System.Collections.Generic;
using System.Text;

namespace PBL6.Hreo.Models
{
    public class PushNotificationRequest
    {
        public string To { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Body { get; set; }
    }
}
