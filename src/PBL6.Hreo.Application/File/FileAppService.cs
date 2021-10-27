using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FileService;
using FileService.Container;
using FileService.FileRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PBL6.Hreo.File;
using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace PBL6.Hreo.Services
{
    public class FileAppService : 
        CrudAppService<
            FileInformation, 
            FileInformationModel, 
            Guid, 
            PagedAndSortedResultRequestDto, 
            CreateUpdateFileInformationDto, 
            CreateUpdateFileInformationDto>,
        IFileAppService, ITransientDependency
    {
        private readonly IBlobContainer<FileContainer> _fileContainer;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _config;

        public FileAppService(
            IRepository<FileInformation, Guid> repository,
            IBlobContainer<FileContainer> fileContainer,
            BlobServiceClient blobServiceClient, 
            IConfiguration config) : base(repository)
        {
            _fileContainer = fileContainer;
            _blobServiceClient = blobServiceClient;
            _config = config;
        }

        protected virtual async Task<CreateFileResponse> MapToCreateOutputDtoAsync(CreateUpdateFileInformationDto file)
        {
            var result = new CreateFileResponse
            {
                FileInfo = new FileInformationModel
                {
                    Id = file.Id,
                    Application = file.Application,
                    Name = file.Name,
                    Extension = file.Extension,
                    Mime = file.Mime,
                    Size = file.Size,
                    Type = file.Type,
                    Url = file.Url
                }
            };

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<string>> ListBlobsAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("public-uploading");
            var items = new List<string>();

            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(_config["FileService:ImgPath"] + blobItem.Name);
            }
            return items;
        }

        public async Task<CreateFileResponse> UploadFileBlobAsync(IFormFile file)
        {
            var fileName = file.FileName;
            var extension = System.IO.Path.GetExtension(fileName);

            var entity = new CreateUpdateFileInformationDto
            {
                Id = Guid.NewGuid(),
                Application = "ALL",
                Name = fileName,
                Extension = extension,
                Type = 1,
                Url = _config["FileService:ImgPath"] + fileName,
            };

            // Insert to db
            await this.CreateAsync(entity);

            // Insert to BLOB
            var containerClient = _blobServiceClient.GetBlobContainerClient("public-uploading");
            var blobClient = containerClient.GetBlobClient(fileName);
            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var blobInfo = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if (blobInfo != null) return await MapToCreateOutputDtoAsync(entity); 
            return null;
        }

    }
}
