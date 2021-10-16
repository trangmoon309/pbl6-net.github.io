using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBL6.Hreo.Models;
using PBL6.Hreo.Services;
using Volo.Abp.Application.Dtos;

namespace Greenglobal.Erp.Controllers
{
    [Route("api/roles")]
    public class RoleController : Controller
    {
        private readonly IRoleAppService _service;

        public RoleController(IRoleAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync(string filter, PagedResultRequestDto input)
        {
            var result = await _service.GetListAsync(filter, input);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var ressult = await _service.GetAsync(id);
            return Ok(ressult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(RoleRequest request)
        {
            var result = await _service.CreateAsync(request);
            return CreatedAtAction(null, result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, RoleRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            return Ok(result);
        }

        [HttpGet]
        [Route("codes")]
        public IActionResult GetRoleCodes()
        {
            var result = _service.GetRoleCodes();
            return Ok(result);
        }
    }
}
