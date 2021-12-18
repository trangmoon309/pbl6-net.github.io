using PBL6.Hreo.Entities;
using PBL6.Hreo.Models;
using PBL6.Hreo.Repository;
using PBL6.Hreo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace PBL6.Hreo.Services
{
    public class BranchAppService : CrudAppService<
            Branch,
            BranchResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            BranchRequest,
            BranchRequest>,
        IBranchAppService
    {
        private readonly IBranchRepository _repository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly ICompanyRepository _company;

        public BranchAppService(IBranchRepository repository,
            IAsyncQueryableExecuter asyncQueryableExecuter, ICompanyRepository company) : base(repository)
        {
            _repository = repository;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            _company = company;
        }

        public async Task SeedBranchData()
        {
            try
            {
                var companies = await _company.GetListAsync();
                var entities = new List<Branch>();

                foreach(var item in companies)
                {
                    var createedBranch1 = new Branch
                    {
                        City = "Hồ Chí Minh",
                        Address = "Quận 1",
                        ImageUrl = item.LogoUrl,
                        CompanyId = item.Id
                    };

                    EntityHelper.TrySetId(createedBranch1, GuidGenerator.Create);

                    var createedBranch2 = new Branch
                    {
                        City = "Đà Nẵng",
                        Address = "Hải Châu",
                        ImageUrl = item.LogoUrl,
                        CompanyId = item.Id
                    };

                    EntityHelper.TrySetId(createedBranch1, GuidGenerator.Create);

                    var createedBranch3 = new Branch
                    {
                        City = "Hà Nội",
                        Address = "Bạch Mai",
                        ImageUrl = item.LogoUrl,
                        CompanyId = item.Id
                    };

                    EntityHelper.TrySetId(createedBranch1, GuidGenerator.Create);
                    EntityHelper.TrySetId(createedBranch2, GuidGenerator.Create);
                    EntityHelper.TrySetId(createedBranch3, GuidGenerator.Create);

                    entities.Add(createedBranch1);
                    entities.Add(createedBranch2);
                    entities.Add(createedBranch3);
                }

                await _repository.InsertManyAsync(entities);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
