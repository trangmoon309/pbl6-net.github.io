﻿using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace PBL6.Hreo.Services
{
    public class InterestedPostAppService : CrudAppService<
            InterestedPost,
            InterestedPostResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            InterestedPostRequest,
            InterestedPostRequest>, IInterestedPostAppService
    {
        private readonly IInterestedPostRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;

        public InterestedPostAppService(IInterestedPostRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
        }
    }
}
