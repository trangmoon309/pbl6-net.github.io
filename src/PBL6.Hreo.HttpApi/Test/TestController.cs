using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PBL6.Hreo.Models;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Controllers
{
    [Route("api/tests")]
    public class TestController : HreoController
    {
        private readonly ITestAppService _service;

        public TestController(ITestAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(PagedAndSortedResultRequestDto input)
        {
            var testList = await _service.GetListAsync(input);

            return Ok(testList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("by-postId/{postId}")]
        public async Task<IActionResult> GetByPostIdAsync(Guid postId)
        {
            var result = await _service.GetTestByPost(postId);
            return Ok(result);
        }

        [HttpGet]
        [Route("get-submitted-assignment")]
        public async Task<IActionResult> GetAssignmentByCondition(Guid applicantId, Guid postId)
        {
            var result = await _service.GetAssignmentByCondition(applicantId, postId);
            return Ok(result);
        }


        [HttpGet]
        [Route("by-condition")]
        public async Task<IActionResult> GetListByConditionAsync(SearchTestRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            var result = await _service.GetListByCondittion(request, pageRequest);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TestRequest request)
        {
            var createdTest = await _service.CreateAsync(request);
            return Ok(createdTest);
        }

        [HttpPost]
        [Route("with-quetions")]
        public async Task<IActionResult> CreateWithQuestionAsync([FromBody]TestWithQuestionRequest request)
        {
            var createdTest = await _service.CreateWithQuestionsAsync(request);
            return Ok(createdTest);
        }
                
        [HttpPost]
        [Route("import-questions")]
        public IActionResult ImportQuestionAsync(IFormFile importExcelFile)
        {
            var createdTest = _service.ImportExcelForCreatingTest(importExcelFile);
            return Ok(createdTest);
        }

        [HttpPost]
        [Route("create-assignment")]
        public async Task<IActionResult> CreateAssignment([FromBody] SendApplicantAssignmentRequest request)
        {
            var createdTest = await _service.MarkAssignment(request);
            return Ok(createdTest);
        }

        [HttpPut]
        [Route("with-quetions/{id}")]
        public async Task<IActionResult> UpdateWithQuestionAsync(Guid id, [FromBody] TestWithQuestionRequest request)
        {
            var createdTest = await _service.UpdateWithQuestionsAsync(id, request);
            return Ok(createdTest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, TestRequest request)
        {
            var createdTest = await _service.UpdateAsync(id, request);
            return Ok(createdTest);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
