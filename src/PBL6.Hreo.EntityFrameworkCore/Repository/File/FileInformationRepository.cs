using PBL6.Hreo.EntityFrameworkCore;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace FileService.FileRepository
{
    public class FileInformationRepository : EfCoreRepository<IHreoDbContext, FileInformation, Guid>, IFileRepository
    {
        public FileInformationRepository(IDbContextProvider<IHreoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}