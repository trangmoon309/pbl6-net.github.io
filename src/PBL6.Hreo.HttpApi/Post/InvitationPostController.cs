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
    [Route("api/invitation-posts")]
    public class InvitationPostController : HreoController
    {
        private readonly IInvitationPostAppService _service;

        public InvitationPostController(IInvitationPostAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(PagedAndSortedResultRequestDto input)
        {
            var invitation_postList = await _service.GetListAsync(input);

            return Ok(invitation_postList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InvitationPostRequest request)
        {
            var createdInvitation_Post = await _service.CreateAsync(request);
            return Ok(createdInvitation_Post);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, InvitationPostRequest request)
        {
            var updatedInvitation_Post = await _service.UpdateAsync(id, request);
            return Ok(updatedInvitation_Post);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
