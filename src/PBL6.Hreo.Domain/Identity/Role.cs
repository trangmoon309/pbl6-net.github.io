using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;


namespace PBL6.Hreo.Entities
{
    [Table("AbpRoles")]
    public class Role : Entity<Guid>, IHasExtraProperties, IHasConcurrencyStamp
    {
        public Guid? TenantId { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public bool IsDefault { get; set; }

        [DefaultValue(false)]
        public bool IsStatic { get; set; }

        public bool IsPublic { get; set; }

        public ExtraPropertyDictionary ExtraProperties { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}
