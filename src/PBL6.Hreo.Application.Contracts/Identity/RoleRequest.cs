using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Models
{
    public class RoleRequest
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public bool IsDefault { get; set; }

        public bool IsPublic { get; set; }

        public bool IsShowAllBranch { get; set; }
    }
}
