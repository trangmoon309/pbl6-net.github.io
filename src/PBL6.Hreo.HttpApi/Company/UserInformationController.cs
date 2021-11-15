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
    [Route("api/user-informations")]
    public class UserInformationController : HreoController
    {
        private readonly IUserInformationAppService _service;

        public UserInformationController(IUserInformationAppService service)
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
        public async Task<IActionResult> CreateAsync(UserInformationRequest request)
        {
            try
            {
                var createdTest = await _service.CreateAsync(request);
                return Ok(createdTest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, UserInformationRequest request)
        {
            try
            {
                var createdTest = await _service.UpdateAsync(id, request);
                return Ok(createdTest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("by-user/{userId}")]
        public async Task<IActionResult> GetByUserAsync(Guid userId)
        {
            try
            {
                var result = await _service.GetByUserId(userId);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("current-user")]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            try
            {
                var result = await _service.GetCurrentUserInformation();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
