using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    public class PostRequest
    {
        public string Title { get; set; }

        public Language Language { get; set; }

        public string Content { get; set; }

        public int Number { get; set; }

        public Level Level { get; set; }

        public PostStatus PostStatus { get; set; }

        public int DateRange { get; set; }

        public bool IsHidden { get; set; }
    }
}
