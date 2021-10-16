using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace PBL6.Hreo.Models
{
    public class RoleResponse : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string NormalizedName { get; set; }

        public List<string> PermissionGrants { get; set; }
    }
}
