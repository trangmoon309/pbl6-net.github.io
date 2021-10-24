using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class UserInformation : FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }

        public Guid? BranchId { get; set; }

        public string WorkAddress { get; set; }

        public string GithubLink { get; set; }

        public Language Language { get; set; }

        public Level Level { get; set; }

        public UserStatus Status { get; set; }

        public Major Major { get; set; }

        public Branch Branch { get; set; }
    }
}
