using System;

namespace PBL6.Hreo.Models
{
    public class SearchUserRequest
    {
        public string KeyWord { get; set; }

        public Guid? RoleId { get; set; }
    }
}
