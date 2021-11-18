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
    [Route("api/interested-posts")]
    public class InterestedPostController : HreoController
    {
        private readonly IInterestedPostAppService _service;

        public InterestedPostController(IInterestedPostAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList(PagedAndSortedResultRequestDto input)
        {
            var interested_postList = await _service.GetListAsync(input);

            return Ok(interested_postList);
        }

        [HttpGet]
        [Route("by-conditions")]
        public async Task<IActionResult> GetList(SearchInterestPostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            var postList = await _service.GetListByCondittion(request, pageRequest);
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
        public async Task<IActionResult> CreateAsync([FromBody]InterestedPostRequest request)
        {
            var createdInterested_Post = await _service.CreateAsync(request);
            return Ok(createdInterested_Post);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] InterestedPostRequest request)
        {
            var updatedInterested_Post = await _service.UpdateAsync(id, request);
            return Ok(updatedInterested_Post);
        }

        [HttpPut]
        [Route("change-status/{id}")]
        public async Task<IActionResult> UpdateStatusAsync(Guid id, InterestedPostStatus request)
        {
            var updatedInterested_Post = await _service.UpdateStatus(id, request);
            return Ok(updatedInterested_Post);
        }


        [HttpDelete]
        [Route("remove-submited-cv")]
        public async Task<IActionResult> DeleteAsync(Guid applicantId, Guid postId)
        {
            await _service.DeleteByContidion(applicantId, postId);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
