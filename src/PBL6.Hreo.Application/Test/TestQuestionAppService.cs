using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Linq;

namespace PBL6.Hreo.Services
{
    public class TestQuestionAppService : CrudAppService<
            TestQuestion,
            TestQuestionResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            TestQuestionRequest,
            TestQuestionRequest>, ITestQuestionAppService
    {
        private readonly ITestQuestionRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;

        public TestQuestionAppService(ITestQuestionRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
        }
    }
}
