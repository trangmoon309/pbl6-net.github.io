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
using Volo.Abp.Domain.Entities;
using Volo.Abp.Linq;
using Volo.Abp.Users;
using static PBL6.Hreo.Common.Enum.Enum;

namespace PBL6.Hreo.Services
{
    [RemoteService(IsMetadataEnabled = false)]
    public class RoleAppService :
        CrudAppService<
            Role,
            RoleResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            RoleRequest,
            RoleRequest>,
        IRoleAppService
    {
        private readonly IRoleRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly IConfiguration _config;

        public RoleAppService(
            IRoleRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IConfiguration config
           ) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _config = config;
        }

        public async Task<PagedResultDto<RoleResponse>> GetListAsync(string filter, PagedResultRequestDto input)
        {
            var query = await _repository.GetList();

            if (!filter.IsNullOrEmpty())
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
            }

            var total = query.Count();

            query = query.OrderBy(x => x.Name);
            var items = await _asyncQueryableExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));
            var result = ObjectMapper.Map<List<Role>, List<RoleResponse>>(items);

            return new PagedResultDto<RoleResponse>(total, result);
        }

        public override async Task<RoleResponse> GetAsync(Guid id)
        {
            var role = await _repository.GetAsync(id);

            if (role != null)
            {
                var response = ObjectMapper.Map<Role, RoleResponse>(role);
                return response;
            }

            return null;
        }

        public override async Task<RoleResponse> CreateAsync(RoleRequest request)
        {
            try
            {
                // Check name
                var check =  _repository.GetByNormalizedName(request.Name).Result.FirstOrDefault();
                if (check != null)
                {
                    throw new UserFriendlyException("Role không tồn tại.");
                }

                // Check code
                if (!string.IsNullOrEmpty(request.Code) && !Enum.IsDefined(typeof(RoleCodes), request.Code))
                {
                    throw new UserFriendlyException("Role Code không tồn tại");
                }

                var entity = base.MapToEntity(request);

                EntityHelper.TrySetId(entity, GuidGenerator.Create);
                entity.NormalizedName = request.Name.ToUpper();
                entity.ConcurrencyStamp = Guid.NewGuid().ToString();
                entity.ExtraProperties = new ExtraPropertyDictionary();
                entity.ExtraProperties.Add("RoleCode", request.Code);
                entity.ExtraProperties.Add("IsShowAllBranch", request.IsShowAllBranch);

                await _repository.InsertAsync(entity);

                return ObjectMapper.Map<Role, RoleResponse>(entity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override async Task<RoleResponse> UpdateAsync(Guid id, RoleRequest request)
        {
            try
            {
                // Check name
                var check = _repository.GetByNormalizedName(request.Name).Result.FirstOrDefault();
                if (check != null && check.Id != id)
                {
                    throw new UserFriendlyException("Role không tồn tại.");
                }

                // Check code
                if (!string.IsNullOrEmpty(request.Code) && !Enum.IsDefined(typeof(RoleCodes), request.Code))
                {
                    throw new UserFriendlyException("Role Code không tồn tại");
                }

                var role = await _repository.GetAsync(id);
                if (role != null)
                {
                    var oldName = role.Name;

                    role.Name = request.Name;
                    role.IsDefault = request.IsDefault;
                    role.IsPublic = request.IsPublic;
                    role.NormalizedName = request.Name.ToUpper();

                    if (role.ExtraProperties.Count > 0 && role.ExtraProperties.ContainsKey("RoleCode"))
                    {
                        role.ExtraProperties["RoleCode"] = request.Code;
                    }
                    else
                    {
                        role.ExtraProperties.Add("RoleCode", request.Code);
                    }

                    if (role.ExtraProperties.Count > 0 && role.ExtraProperties.ContainsKey("IsShowAllBranch"))
                    {
                        role.ExtraProperties["IsShowAllBranch"] = request.IsShowAllBranch;
                    }
                    else
                    {
                        role.ExtraProperties.Add("IsShowAllBranch", request.IsShowAllBranch);
                    }

                    await _repository.UpdateAsync(role);

                    return ObjectMapper.Map<Role, RoleResponse>(role);
                }

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<RoleResponse>> GetAllAsync()
        {
            try
            {
                var roles = await _repository.GetListAsync();

                if (roles.Count > 0)
                {
                    var result = ObjectMapper.Map<List<Role>, List<RoleResponse>>(roles);

                    return result;
                }

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> GetRoleCodes()
        {
            return Enum.GetNames(typeof(RoleCodes)).ToList();
        }
    }
}
