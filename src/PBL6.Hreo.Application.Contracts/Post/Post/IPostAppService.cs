using PBL6.Hreo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Services
{
    public interface IPostAppService : ICrudAppService<
                PostResponse,
                Guid,
                PagedAndSortedResultRequestDto,
                PostRequest,
                PostRequest>
    {
        Task<PagedResultDto<PostResponse>> GetListByCondittion(SearchPostRequest request, PagedAndSortedResultRequestDto pageRequest);

        Task<PostResponse> HiddenPost(Guid id);
    }
}
