using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;

namespace PBL6.Hreo.Models
{
    public class UserRequest
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
       
        public List<string> Roles { get; set; }
    }
}
