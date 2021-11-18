using FileService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Entities
{
    public class UserResume : FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }

        public string ResumeName { get; set; }

        public string JobTitle { get; set; }

        public Guid FileInformationId { get; set; }

        public FileInformation FileInformation { get; set; }
    }
}
