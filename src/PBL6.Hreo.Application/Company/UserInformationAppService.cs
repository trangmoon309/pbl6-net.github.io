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
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUser _currentUser;

        public UserInformationAppService(IUserInformationRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IUserRepository userRepository, 
            ICurrentUser currentUser) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _userRepository = userRepository;
            _currentUser = currentUser;
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


        public async Task<UserInformationResponse> GetByUserId(Guid userId)
        {
            try
            {
                var user = _userRepository.GetById(userId);
                var response = new UserInformationResponse();

                if(user!=null && user.Any())
                {
                    var userInformation = await _repository.GetByUserId(userId);
                    var userAbp = await _asyncQueryableExecuter.FirstOrDefaultAsync(user);
                    var userAbpResponse = ObjectMapper.Map<User, UserResponse>(userAbp);

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

        public async Task<UserInformationResponse> GetCurrentUserInformation()
        {
            try
            {
                var response = new UserInformationResponse();

                if (_currentUser.Id.HasValue)
                {
                    var user = _userRepository.GetById(_currentUser.Id.Value);

                    if (user != null && user.Any())
                    {
                        var userAbp = await _asyncQueryableExecuter.FirstOrDefaultAsync(user);
                        var userAbpResponse = ObjectMapper.Map<User, UserResponse>(userAbp);

                        var userInformation = await _repository.GetByUserId(userAbp.Id);

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
    }
}
