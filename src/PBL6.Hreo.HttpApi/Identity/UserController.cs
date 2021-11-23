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

        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await _service.GetCurrentUser();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync([FromBody]UserRequest request)
        {
            try
            {
                var result = await _service.SignUpCustom(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
