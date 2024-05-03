using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace financas.Services.Interfaces;

public interface ITokenService
{
    JwtSecurityToken GenerateToKen(IEnumerable<Claim> claims, IConfiguration _config);
    string GenereteRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config);
}