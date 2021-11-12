using System;
using System.Collections.Generic;
using System.Text;

namespace PBL6.Hreo.Models
{
    public class PushNotificationResponse
    {
        public List<Data> Data { get; set; }
    }

    public class Data
    {
        public string Status { get; set; }
        public string Id { get; set; }
    }
}
