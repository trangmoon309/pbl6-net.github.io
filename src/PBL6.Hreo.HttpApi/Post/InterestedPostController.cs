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
    [Route("api/interested-posts")]
    public class InterestedPostController : Controller
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

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InterestedPostRequest request)
        {
            var createdInterested_Post = await _service.CreateAsync(request);
            return Ok(createdInterested_Post);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, InterestedPostRequest request)
        {
            var updatedInterested_Post = await _service.UpdateAsync(id, request);
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
