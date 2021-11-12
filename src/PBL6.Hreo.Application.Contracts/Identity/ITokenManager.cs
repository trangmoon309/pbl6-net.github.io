using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Greenglobal.Erp.Models;
using Volo.Abp.Application.Services;

namespace Greenglobal.Erp.Services
{
    public interface ITokenManager : IApplicationService
    {
        Task<TokenResponse> GenerateToken(Guid userId);

        ClaimsPrincipal VerifyToken(string accessToken);
    }
}