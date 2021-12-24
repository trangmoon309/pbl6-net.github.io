using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class PostResponse : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Language { get; set; }

        public string Content { get; set; }

        public int Number { get; set; }

        public Level Level { get; set; }

        public string PostStatus { get; set; }

        public int DateRange { get; set; }

        public bool IsHidden { get; set; }

        public bool IsFavorite { get; set; }

        public UserInformationResponse Creator { get; set; }

        public BranchResponse Branch { get; set; }

        public List<PostTestResponse> PostTests { get; set; }
    }
}
