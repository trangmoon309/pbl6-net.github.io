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
    [Route("api/posts")]
    public class PostController: HreoController
    {
        private readonly IPostAppService _service;

        public PostController(IPostAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("by-conditions")]
        public async Task<IActionResult> GetList(SearchPostRequest request, PagedAndSortedResultRequestDto pageRequest)
        {
            var postList = await _service.GetListByCondittion(request, pageRequest);
            return Ok(postList);
        }

        [HttpGet]
        public async Task<IActionResult> GetList(PagedAndSortedResultRequestDto input)
        {
            var postList = await _service.GetListAsync(input);

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
        public async Task<IActionResult> CreateAsync([FromBody]PostRequest request)
        {
            var createdPost = await _service.CreateAsync(request);
            return Ok(createdPost);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] PostRequest request)
        {
            var updatedPost = await _service.UpdateAsync(id, request);
            return Ok(updatedPost);
        }

        [HttpPut]
        [Route("hidden/{id}")]
        public async Task<IActionResult> HiddenPostAsync(Guid id)
        {
            var updatedPost = await _service.HiddenPost(id);
            return Ok(updatedPost);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
