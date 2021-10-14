using System;
using System.Collections.Generic;
using System.Text;
using PBL6.Hreo.Entities;
using Volo.Abp.Domain.Repositories;

namespace PBL6.Hreo.Repository
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
    }
}
