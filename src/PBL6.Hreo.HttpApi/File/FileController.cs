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
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

namespace FileService.Controllers
{
    [Route("api/files")]
    public class FileController : HreoController
    {
        private readonly IFileAppService _fileAppService;

        public FileController(IFileAppService fileAppService)
        {
            _fileAppService = fileAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await _fileAppService.ListBlobsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("paged")]
        public async Task<IActionResult> GetList(PagedAndSortedResultRequestDto input)
        {
            var postList = await _fileAppService.GetListAsync(input);

            return Ok(postList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _fileAppService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("uploading")]
        public async Task<IActionResult> UploadFileASync(IFormFile file)
        {
            var result = await _fileAppService.UploadFileBlobAsync(file);
            return Ok(result);
        }
    }
}
