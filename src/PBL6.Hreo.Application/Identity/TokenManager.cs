using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Greenglobal.Erp.Models;
using Greenglobal.Erp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PBL6.Hreo.Entities;
using PBL6.Hreo.Repository;
using Volo.Abp.Security.Claims;

namespace Greenglobal.Erp
{
    public class TokenManager : ITokenManager
    {
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly byte[] _secretKey;

        public TokenManager(
            ICurrentPrincipalAccessor currentPrincipalAccessor,
            IUserRepository userRepository,
            IConfiguration config)
        {
            _currentPrincipalAccessor = currentPrincipalAccessor;
            _userRepository = userRepository;
            _config = config;

            _tokenHandler = new JwtSecurityTokenHandler();
            _secretKey = Encoding.ASCII.GetBytes(_config["AuthServer:SecretKey"]);
        }

        public async Task<TokenResponse> GenerateToken(Guid userId)
        {
            TokenResponse token = new TokenResponse();

            try
            {
                var user = await _userRepository.GetAsync(userId);

                if (user != null)
                {
                    var expiresDate = DateTime.UtcNow.AddDays(365);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(CreateClaims(user)),
                        Expires = expiresDate,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var securityToken = _tokenHandler.CreateToken(tokenDescriptor);
                    var accessToken = _tokenHandler.WriteToken(securityToken);

                    token.AccessToken = accessToken;
                    token.ExpiresIn = expiresDate;
                }
            }
            catch
            {
                return null;
            }

            return token;
        }

        public ClaimsPrincipal VerifyToken(string accessToken)
        {
            var claims = _tokenHandler.ValidateToken(accessToken.Replace("Bearer ", ""),
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(_secretKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

            _currentPrincipalAccessor.Change(claims);

            return claims;
        }

        private IEnumerable<Claim> CreateClaims(User user)
        {
            var scopes = new[]
            {
                "address",
                "email",
                "Erp",
                "openid",
                "phone",
                "profile",
                "role",
                "offline_access"
            };

            var claims = new List<Claim>
            {
                new Claim("iss", _config["AuthServer:Authority"]),
                new Claim(AbpClaimTypes.UserId, user.Id.ToString()),
                new Claim(AbpClaimTypes.Email, user.Email),
                new Claim(AbpClaimTypes.UserName, user.UserName),
                new Claim(AbpClaimTypes.EmailVerified, user.EmailConfirmed.ToString().ToLower()),
            };

            if (!string.IsNullOrWhiteSpace(user.PhoneNumber))
            {
                claims.Add(new Claim(AbpClaimTypes.PhoneNumber, user.PhoneNumber));
                claims.Add(new Claim(AbpClaimTypes.PhoneNumberVerified, user.PhoneNumberConfirmed.ToString()));
            }

            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(AbpClaimTypes.Role, role));
            //}

            foreach (var scope in scopes)
            {
                claims.Add(new Claim("scope", scope));
            }

            return claims;
        }
    }
}
