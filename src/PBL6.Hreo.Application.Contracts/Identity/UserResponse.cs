using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Models
{
    public class UserResponse : EntityDto<Guid>
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<RoleResponse> Roles { get; set; }

        public string Role { get; set; }

        public string RoleCode { get; set; }

        public Guid? RoleId { get; set; }
    }
}
