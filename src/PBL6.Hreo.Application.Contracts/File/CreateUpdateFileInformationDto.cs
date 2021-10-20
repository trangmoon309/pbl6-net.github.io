using System;

namespace PBL6.Hreo.Models
{
    [Serializable]
    public class CreateUpdateFileInformationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Mime { get; set; }

        public int Size { get; set; }
        public string Extension { get; set; }

        public string Url { get; set; }

        public int Type { get; set; }

        public string Application { get; set; }

        public string FullPathAndName { get; set; }
    }
}