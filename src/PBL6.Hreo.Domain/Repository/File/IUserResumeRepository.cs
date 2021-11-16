using PBL6.Hreo.Entities;
using System;
using Volo.Abp.Domain.Repositories;

namespace FileService.FileRepository
{
    public interface IUserResumeRepository : IRepository<UserResume, Guid>
    {
    }
}