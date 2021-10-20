using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace FileService
{
    public partial class FileInformation : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Mime { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
        public string Application { get; set; }

        protected FileInformation()
        {
        }

        public FileInformation(
            Guid id,
            string name,
            string mime,
            int size,
            string extension,
            string url,
            int type,
            string application
        ) : base(id)
        {
            Name = name;
            Mime = mime;
            Size = size;
            Extension = extension;
            Url = url;
            Type = type;
            Application = application;
        }
    }
}
