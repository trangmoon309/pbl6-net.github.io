using Microsoft.AspNetCore.Http;
using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Services
{
    public interface ITestAppService : ICrudAppService<
                TestResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                TestRequest,
                TestRequest>
    {
        Task<TestWithQuestionResponse> CreateWithQuestionsAsync(TestWithQuestionRequest input);

        List<TestQuestionRequest> ImportExcelForCreatingTest(IFormFile importExcelFile);

        Task<TestWithQuestionResponse> UpdateWithQuestionsAsync(Guid id, TestWithQuestionRequest input);

        Task<PagedResultDto<TestResponse>> GetListByCondittion(SearchTestRequest request, PagedAndSortedResultRequestDto pageRequest);
    }
}
