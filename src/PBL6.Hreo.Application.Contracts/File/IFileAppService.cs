using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.File
{
    public interface IFileAppService : ICrudAppService<
            FileInformationModel,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateFileInformationDto,
            CreateUpdateFileInformationDto>
    {
        Task<CreateFileResponse> CreateFileAsync(CreateFileRequest input);

        Task<List<FileInformationModel>> GetFileInfoListAsync(List<Guid> fileIds);
    }
}
