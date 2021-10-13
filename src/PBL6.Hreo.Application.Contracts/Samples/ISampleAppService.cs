using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace PBL6.Hreo.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
