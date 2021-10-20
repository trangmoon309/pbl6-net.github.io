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

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TestRequest request)
        {
            var createdTest = await _service.CreateAsync(request);
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
