using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Models
{
    [Serializable]
    public class CreateFileRequest : IValidatableObject
    {
        //[Required]
        //public string FileContainerName { get; set; }

        [Required]
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public FileType FileType { get; set; }

        public long Length { get; set; }

        public Guid? ParentId { get; set; }

        public Guid? OwnerUserId { get; set; }

        public byte[] Content { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FileName.IsNullOrWhiteSpace())
            {
                yield return new ValidationResult("FileName should not be empty!",
                    new[] { nameof(FileName) });
            }

            //if (FileContainerName.IsNullOrWhiteSpace())
            //{
            //    yield return new ValidationResult("FileContainerName should not be empty!",
            //        new[] { nameof(FileContainerName) });
            //}

            //if (!Enum.IsDefined(typeof(FileType), FileType))
            //{
            //    yield return new ValidationResult("FileType is invalid!",
            //        new[] { nameof(FileType) });
            //}

            //FileName = FileName.Trim();
        }
    }
}
