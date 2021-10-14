using PBL6.Hreo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IInterestedPostRepository : IRepository<InterestedPost, Guid>
    {
    }
}
