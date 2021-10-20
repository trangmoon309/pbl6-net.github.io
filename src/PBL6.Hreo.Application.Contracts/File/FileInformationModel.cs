using System;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Models
{
    [Serializable]
    public class FileInformationModel : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Mime { get; set; }

        public int Size { get; set; }

        public string Extension { get; set; }

        public string Url { get; set; }

        public int Type { get; set; }

        public string Application { get; set; }
    }
}