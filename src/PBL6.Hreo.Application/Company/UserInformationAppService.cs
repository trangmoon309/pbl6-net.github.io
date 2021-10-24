using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace PBL6.Hreo.Services
{
    public class UserInformationAppService : CrudAppService<
            UserInformation,
            UserInformationResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            UserInformationRequest,
            UserInformationRequest>, IUserInformationAppService
    {
        private readonly IUserInformationRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;

        public UserInformationAppService(IUserInformationRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
        }

        public override async Task<PagedResultDto<UserInformationResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _repository.GetList();
            
            var toList = await _asyncQueryableExecuter.ToListAsync(query);
            var count = toList.Count();

            toList = toList.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var responses = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(toList);
            return new PagedResultDto<UserInformationResponse>(count, responses);
        }
    }
}
