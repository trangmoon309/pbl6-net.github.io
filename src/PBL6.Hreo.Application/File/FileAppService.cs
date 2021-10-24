using FileService;
using FileService.Container;
using FileService.FileRepository;
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

        public FileAppService(
            IRepository<FileInformation, Guid> repository,
            IBlobContainer<FileContainer> fileContainer
        ): base(repository)
        {
            _fileContainer = fileContainer;
        }

        public async Task<List<FileInformationModel>> GetFileInfoListAsync(List<Guid> fileIds)
        {
            var query = Repository.Where(x => fileIds.Contains(x.Id));
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<FileInformation>, List<FileInformationModel>>(data);
        }

        public virtual async Task<CreateFileResponse> CreateFileAsync(CreateFileRequest input)
        {
            var id = GuidGenerator.Create();
            var date = DateTime.Today;
            var year = date.ToString("yyyy"); var month = date.ToString("MM"); var ymd = date.ToString("yyyyMMdd");

            var extension = System.IO.Path.GetExtension(input.FileName);

            var fullPathAndName = System.IO.Path.Combine(year, month, ymd, $"{id}{extension}");

            var file = new CreateUpdateFileInformationDto
            {
                Id = id,
                Application = "ALL",
                Mime = input.MimeType,
                Name = $"{input.FileName}",
                Size = Convert.ToInt32(input.Length),
                Extension = extension,
                Type = 1,
                Url = $"/file-storage/{fullPathAndName.Replace("\\", "/")}",
                FullPathAndName = fullPathAndName
            };

            // Save file to blob
            await TrySaveBlobAsync(file, input.Content);

            // Insert to db
            await this.CreateAsync(file);

            return await MapToCreateOutputDtoAsync(file);
        }

        public async Task<bool> TrySaveBlobAsync(CreateUpdateFileInformationDto file, byte[] fileContent, bool overrideExisting = false, CancellationToken cancellationToken = default)
        {
            await _fileContainer.SaveAsync(file.FullPathAndName, fileContent, overrideExisting, cancellationToken: cancellationToken);

            return true;
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
    }
}
