using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;


namespace PBL6.Hreo.Entities
{
    [Table("AbpUserRoles")]
    public class UserRole : Entity<string>
    {
        [NotMapped]
        public override string Id
        {
            get { return string.Empty; }
        }

        public Guid? TenantId { get; set; }

        [Key]
        public Guid UserId { get; set; }

        [Key]
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
