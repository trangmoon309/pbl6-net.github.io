using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBL6.Hreo;
using PBL6.Hreo.File;
using PBL6.Hreo.Models;
using Volo.Abp;
using static PBL6.Hreo.Common.Enum.Enum;

namespace FileService.Controllers
{
    [Route("api/file-informations")]
    public class FileController : HreoController
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadAsync(List<IFormFile> files)
        {
            var data = new List<CreateFileResponse>();
            foreach (var item in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await item.CopyToAsync(memoryStream);

                    var result = await _fileAppService.CreateFileAsync(new CreateFileRequest
                    {
                        FileName = item.FileName,
                        MimeType = item.ContentType,
                        FileType = FileType.File,
                        ParentId = null,
                        OwnerUserId = null,
                        Length = item.Length,
                        Content = memoryStream.ToArray()
                    });

                    data.Add(result);
                }
            }

            return Ok(new
            {
                total = data != null && data.Count > 0 ? data.Count : -1,
                results = data
            });
        }
       
        [HttpGet]
        public async Task<IActionResult> GetFileInfoListAsync(List<Guid> fileIds)
        {
            var data = await _fileAppService.GetFileInfoListAsync(fileIds);
            return Ok(new
            {
                total = data.Count,
                results = data
            });
        }
    }
}
