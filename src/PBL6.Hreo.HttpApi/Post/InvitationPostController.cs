using Microsoft.AspNetCore.Mvc;
using PBL6.Hreo.Models;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using static PBL6.Hreo.Common.Enum.Enum;

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

        // Lấy danh sách ứng viên phù hợp với bài post
        [HttpGet]
        [Route("by-conditions/{postId}")]
        public async Task<IActionResult> GetList(Guid postId, SearchInvitePostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            var postList = await _service.GetListByCondittion(postId, request, pageRequest);
            return Ok(postList);
        }

        // Lấy danh sách lời mời theo ứng viên
        [HttpGet]
        [Route("by-applicant/{userInformationId}")]
        public async Task<IActionResult> GetListByApplicant(Guid userInformationId)
        {
            var postList = await _service.GetListByApplicantIdCondittion(userInformationId);
            return Ok(postList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]List<InvitationPostRequest> request)
        {
            var createdInvitation_Post = await _service.CreateMultiple(request);
            return Ok(createdInvitation_Post);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, InvitationPostRequest request)
        {
            var updatedInvitation_Post = await _service.UpdateAsync(id, request);
            return Ok(updatedInvitation_Post);
        }

        [HttpPut]
        [Route("change-status/{id}")]
        public async Task<IActionResult> UpdateStatusAsync(Guid id, InvitationPostStatus request)
        {
            var updatedInterested_Post = await _service.UpdateStatus(id, request);
            return Ok(updatedInterested_Post);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
