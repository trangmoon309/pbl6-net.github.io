using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Linq;
using Volo.Abp.Users;


namespace PBL6.Hreo.Services
{
    [RemoteService(IsMetadataEnabled = false)]
    public class UserAppService :
        CrudAppService<
            User,
            UserResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            UserRequest,
            UserRequest>,
        IUserAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IUserRepository _repository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly IDataFilter _dataFilter;
        private readonly IConfiguration _config;
        private readonly JsonSerializerSettings _toSnakeCase;

        public UserAppService(
            ICurrentUser currentUser,
            IUserRepository repository,
            IUserRoleRepository userRoleRepository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IDataFilter dataFilter,
            IConfiguration config
           ) : base(repository)
        {
            _currentUser = currentUser;
            _repository = repository;
            _userRoleRepository = userRoleRepository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _dataFilter = dataFilter;
            _config = config;

            _toSnakeCase = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy { ProcessDictionaryKeys = true }
                },
                Formatting = Formatting.Indented
            };
        }

        public UserResponse GetCurrentUser()
        {
            try
            {
                var result = new UserResponse();

                if(_currentUser.Id.HasValue)
                {
                    var user = _repository.GetById(_currentUser.Id.Value);

                    if(user != null)
                    {
                        result = ObjectMapper.Map<User, UserResponse>(user.FirstOrDefault());
                    }
                }
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<PagedResultDto<UserResponse>> GetListAsync(SearchUserRequest searchRequest, PagedAndSortedResultRequestDto pageRequest)
        {
            try
            {
                using (_dataFilter.Disable<ISoftDelete>())
                {
                    var query = await _repository.GetList();

                    if (!string.IsNullOrEmpty(searchRequest.KeyWord))
                    {
                        query = query.Where(x => (x.UserName.ToLower().Contains(searchRequest.KeyWord.ToLower()))
                                           || x.Name.ToLower().Contains(searchRequest.KeyWord.ToLower()));
                    }

                    if (searchRequest.RoleId != null && searchRequest.RoleId != Guid.Empty)
                    {
                        query = query.Where(x => x.UserRoles.Any(c => c.RoleId == searchRequest.RoleId));
                    }

                    var listUser = await _asyncQueryableExecuter.ToListAsync(query);
                    var items = ObjectMapper.Map<List<User>, List<UserResponse>>(listUser.Skip(pageRequest.SkipCount).Take(pageRequest.MaxResultCount).ToList());
                    var total = listUser.Count();

                    return new PagedResultDto<UserResponse>(total, items);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
