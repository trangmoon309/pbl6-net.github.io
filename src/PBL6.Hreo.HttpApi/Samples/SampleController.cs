using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Samples
{
    [RemoteService]
    [Route("api/commons")]
    public class SampleController : HreoController, ISampleAppService
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleController(ISampleAppService sampleAppService)
        {
            _sampleAppService = sampleAppService;
        }

        [HttpGet]
        [Route("majors")]
        public IActionResult GetMajorList()
        {
            var majors = Enum.GetValues(typeof(Major))
                .Cast<Major>()
                .Select(v => v.ToString())
                .ToList();
            return Ok(majors);
        }

        [HttpGet]
        [Route("languages")]
        public IActionResult GetLanguageList()
        {
            var majors = Enum.GetValues(typeof(Language))
                .Cast<Major>()
                .Select(v => v.ToString())
                .ToList();
            return Ok(majors);
        }

        [HttpGet]
        [Route("levels")]
        public IActionResult GetLevelList()
        {
            var majors = Enum.GetValues(typeof(Level))
                .Cast<Major>()
                .Select(v => v.ToString())
                .ToList();
            return Ok(majors);
        }

        [HttpGet]
        [Route("authorized")]
        [Authorize]
        public async Task<SampleDto> GetAuthorizedAsync()
        {
            return await _sampleAppService.GetAsync();
        }

        [HttpGet]
        [Route("xxx")]
        public Task<SampleDto> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
