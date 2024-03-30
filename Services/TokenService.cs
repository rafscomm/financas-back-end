using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using financas.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace financas.Services;

public class TokenService: ITokenService
{
    public JwtSecurityToken GenerateToen(IEnumerable<Claim> claims, IConfiguration _config)
    {
        var key = _config.GetSection("JWT").GetValue<string>("Key") ?? throw new ArgumentException("Key invalida");
        var privateKey = Encoding.UTF8.GetBytes(key);

        var singingCredentials =
            new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256Signature);
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_config.GetSection("JWT").GetValue<double>("ExpireTime")),
            Audience = _config.GetSection("JWT").GetValue<string>("ValidAudience"),
            Issuer = _config.GetSection("JWT").GetValue<string>("ValidIssue"),
            SigningCredentials = singingCredentials
        };
        var tokenHanlde = new JwtSecurityTokenHandler();
        var token = tokenHanlde.CreateJwtSecurityToken(tokenDesc);

        return token;
    }

    public string GenereteRefreshToken()
    {
        var secureRandom = new byte[128];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(secureRandom);
        var refreshToken = Convert.ToBase64String(secureRandom);

        return refreshToken;
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, IConfiguration _config)
    {
        var secret = _config["JWT:Key"] ?? throw new ArgumentException("Key invalida");

        var tokenValidateDesc = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
            ValidateLifetime = false
        };
        var tokenHanlde = new JwtSecurityTokenHandler();
        var principal = tokenHanlde.ValidateToken(token, tokenValidateDesc, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityException("Invalid Token");
        }

        return principal;
    }
}