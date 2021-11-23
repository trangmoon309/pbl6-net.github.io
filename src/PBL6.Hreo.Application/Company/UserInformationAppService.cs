using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Linq;
using Volo.Abp.Users;

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
        private readonly ICurrentUser _currentUser;
        protected IdentityUserManager UserManager { get; }
        protected IIdentityUserRepository _userRepository { get; }

        public UserInformationAppService(IUserInformationRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            ICurrentUser currentUser,
            IdentityUserManager userManager, 
            IIdentityUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _currentUser = currentUser;
            UserManager = userManager;
            _userRepository = userRepository;
        }

        public override async Task<PagedResultDto<UserInformationResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var query = _repository.GetList();
            var users = await _userRepository.GetListAsync();
            var userList = ObjectMapper.Map <List<IdentityUser>, List<UserResponse>>(users);

            var toList = await _asyncQueryableExecuter.ToListAsync(query);
            var count = toList.Count();

            toList = toList.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

            var responses = ObjectMapper.Map<List<UserInformation>, List<UserInformationResponse>>(toList);
            foreach (var item in responses)
            {
                var userAbp = userList.FirstOrDefault(x => x.Id.Equals(item.UserId));
                item.UserAbp = userAbp;
            }

            return new PagedResultDto<UserInformationResponse>(count, responses);
        }


        public async Task<UserInformationResponse> GetByUserId(Guid userId)
        {
            try
            {
                var user = await UserManager.GetByIdAsync(userId);
                var response = new UserInformationResponse();

                if(user!=null)
                {
                    var userInformation = await _repository.GetByUserId(userId);
                    var userAbpResponse = ObjectMapper.Map<IdentityUser, UserResponse>(user);

                    if (userInformation != null)
                    {
                        response = ObjectMapper.Map<UserInformation, UserInformationResponse>(userInformation);
                    }

                    response.UserAbp = userAbpResponse;
                    return response;
                }

                else
                {
                    throw new UserFriendlyException("Người dùng đã bị xóa hoặc không tồn tại!");
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<UserInformationResponse> GetByUserInforId(Guid userId)
        {
            try
            {
                var userInformation = await _repository.GetByUserId(userId);

                var response = new UserInformationResponse();

                if (userInformation != null)
                {
                    var user = await UserManager.GetByIdAsync(userId);
                    var userAbpResponse = ObjectMapper.Map<IdentityUser, UserResponse>(user);

                    if (userInformation != null)
                    {
                        response = ObjectMapper.Map<UserInformation, UserInformationResponse>(userInformation);
                    }

                    response.UserAbp = userAbpResponse;
                    return response;
                }

                else
                {
                    throw new UserFriendlyException("Người dùng đã bị xóa hoặc không tồn tại!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UserInformationResponse> GetCurrentUserInformation()
        {
            try
            {
                var response = new UserInformationResponse();

                if (_currentUser.Id.HasValue)
                {
                    var user = await UserManager.GetByIdAsync(_currentUser.Id.Value);

                    if (user != null)
                    {
                        var userAbpResponse = ObjectMapper.Map<IdentityUser, UserResponse>(user);

                        var userInformation = await _repository.GetByUserId(_currentUser.Id.Value);

                        if (userInformation != null)
                        {
                            response = ObjectMapper.Map<UserInformation, UserInformationResponse>(userInformation);
                        }

                        response.UserAbp = userAbpResponse;
                        return response;
                    }

                    else
                    {
                        throw new UserFriendlyException("Người dùng đã bị xóa hoặc không tồn tại!");
                    }
                }
                else
                {
                    throw new UserFriendlyException("Không lấy của Id của CurrentUser!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<UserInformationResponse> UpdateAsync(Guid id, UserInformationRequest input)
        {
            try
            {
                var user = await UserManager.GetByIdAsync(input.UserId);
                var response = await base.UpdateAsync(id, input);

                if (user != null)
                {
                    var userInformation = await _repository.GetByUserId(input.UserId);
                    var userAbpResponse = ObjectMapper.Map<IdentityUser, UserResponse>(user);

                    if (userInformation != null)
                    {
                        response = ObjectMapper.Map<UserInformation, UserInformationResponse>(userInformation);
                    }

                    response.UserAbp = userAbpResponse;
                    return response;
                }

                else
                {
                    throw new UserFriendlyException("Người dùng đã bị xóa hoặc không tồn tại!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<UserInformationResponse> CreateAsync(UserInformationRequest input)
        {
            try
            {
                var user = await UserManager.GetByIdAsync(input.UserId);
                var response = await base.CreateAsync(input);

                if (user != null)
                {
                    var userInformation = await _repository.GetByUserId(input.UserId);
                    var userAbpResponse = ObjectMapper.Map<IdentityUser, UserResponse>(user);

                    if (userInformation != null)
                    {
                        response = ObjectMapper.Map<UserInformation, UserInformationResponse>(userInformation);
                    }

                    response.UserAbp = userAbpResponse;
                    return response;
                }
                else
                {
                    throw new UserFriendlyException("Người dùng đã bị xóa hoặc không tồn tại!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
