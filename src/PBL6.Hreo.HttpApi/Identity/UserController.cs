using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PBL6.Hreo.Models;
using PBL6.Hreo.Services;
using Volo.Abp.Application.Dtos;

namespace PBL6.Hreo.Controllers
{
    [Route("api/users")]
    public class UserController : HreoController
    {
        private readonly IUserAppService _service;

        public UserController(IUserAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync(SearchUserRequest searchRequest, PagedAndSortedResultRequestDto pageRequest)
        {
            var ressult = await _service.GetListAsync(searchRequest, pageRequest);
            return Ok(ressult);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var ressult = await _service.GetAsync(id);
            return Ok(ressult);
        }
    }
}
