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
    [Route("api/branches")]
    public class BranchController : HreoController
    {
        private readonly IBranchAppService _service;

        public BranchController(IBranchAppService service)
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BranchRequest request)
        {
            var createdTest = await _service.CreateAsync(request);
            return Ok(createdTest);
        }


        [HttpPost]
        [Route("seed-datas")]
        public async Task<IActionResult> SeedAsync()
        {
            await _service.SeedBranchData();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] BranchRequest request)
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
