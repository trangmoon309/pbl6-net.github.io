using PBL6.Hreo.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBL6.Hreo.Services
{
    public interface IExpoApi
    {
        [Post("/users/{user}")]
        Task<PushNotificationResponse> PushNotification(List<PushNotificationRequest> request);
    }
}
