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
using PBL6.Hreo.File;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
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
        protected IdentityUserManager UserManager { get; }
        protected IdentityRoleManager RoleManager { get; }
        protected IIdentityRoleRepository _roleRepository { get; }
        private readonly IUserInformationRepository _userInformrepository;
        private readonly IFileAppService _fileAppService;


        public UserAppService(
            ICurrentUser currentUser,
            IUserRepository repository,
            IUserRoleRepository userRoleRepository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IDataFilter dataFilter,
            IConfiguration config,
            IdentityUserManager userManager,
            IdentityRoleManager roleManager,
            IIdentityRoleRepository roleRepository,
            IUserInformationRepository userInformrepository, 
            IFileAppService fileAppService) : base(repository)
        {
            _currentUser = currentUser;
            _repository = repository;
            _userRoleRepository = userRoleRepository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _dataFilter = dataFilter;
            _config = config;
            UserManager = userManager;
            RoleManager = roleManager;
            _roleRepository = roleRepository;
            _userInformrepository = userInformrepository;
            _fileAppService = fileAppService;
        }

        public async Task<UserResponse> GetCurrentUser()
        {
            try
            {
                var result = new UserResponse();

                if(_currentUser.Id.HasValue)
                {
                    var user = await UserManager.GetByIdAsync(_currentUser.Id.Value);

                    if(user != null)
                    {
                        result = ObjectMapper.Map<IdentityUser, UserResponse>(user);
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
                    var userInfors = await _asyncQueryableExecuter.ToListAsync(_userInformrepository.GetList());

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
                    items.ForEach(x =>
                    {
                        var inform = userInfors.FirstOrDefault(y => y.UserId == x.Id);
                        if (inform != null) x.AvatarUrl = _fileAppService.GetAsync(inform.AvatarId).Result.Url;
                    });
                    
                    var total = listUser.Count();

                    return new PagedResultDto<UserResponse>(total, items);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserResponse> SignUpCustom(UserRequest request)
        {
            try
            {
                var newUser = ObjectMapper.Map<UserRequest, IdentityUser>(request);
                EntityHelper.TrySetId(newUser, GuidGenerator.Create);

                var created = await UserManager.CreateAsync(newUser, request.Password);

                if (!created.Succeeded) throw new Exception(created.Errors.Select(x => x.Description).ToList().JoinAsString(","));

                var result = await UserManager.AddToRolesAsync(newUser, request.Roles.AsEnumerable());

                var roles = await _roleRepository.GetListAsync();
                roles = roles.Where(x => request.Roles.Contains(x.Name.ToLower())).ToList();

                var response = ObjectMapper.Map<IdentityUser, UserResponse>(newUser); 
                response.Roles = ObjectMapper.Map<List<IdentityRole>, List<RoleResponse>>(roles);

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
