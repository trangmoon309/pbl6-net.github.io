using System;
using Volo.Abp.Domain.Repositories;

namespace FileService.FileRepository
{
    public interface IFileRepository : IRepository<FileInformation, Guid>
    {
    }
}