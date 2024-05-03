using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using financas.Models.DTO;
using financas.Request;
using financas.Services;
using financas.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace financas.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly IUsuariosService _userService;
    public AuthController(ITokenService tokenService, IConfiguration configuration, IUsuariosService _user)
    {
        _tokenService = tokenService;
        _configuration = configuration;
        _userService = _user;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var usr = await _userService.GetByEmailForAuthorize(user.Email);
        PasswordVerificationResult valid;
        if (usr != null)
        {
            valid = await _userService.ValidatePassword(user.Password, user.Email);  
        }
        else
        {
            return Unauthorized("Usuario não encontrado");
        }
        
        if (usr != null && valid == PasswordVerificationResult.Success)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, usr.Email),
                new Claim(ClaimTypes.Name, usr.Nome),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = _tokenService.GenerateToKen(claims, _configuration);
            var refreshToken = _tokenService.GenereteRefreshToken();
            _ = int.TryParse(_configuration["JWT:ExpireTimeRefresh"], out int refreshTokenTime);
            usr.RefreshTokenTime = DateTime.Now.AddMinutes(refreshTokenTime);
            usr.RefreshToken = refreshToken;

            await _userService.UpdateToken(usr);

            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            });
        }

        return Unauthorized();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenModelRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        string? acessToken = model.AcessToken ?? throw new ArgumentNullException(nameof(model));
        string? refreshToken = model.RefreshToken ?? throw new ArgumentException(nameof(model));

        var principal = _tokenService.GetPrincipalFromExpiredToken(acessToken, _configuration);

        if (principal == null)
        {
            return BadRequest("Invalid acess token/refresh token");
        }

        string user = principal.Claims.ElementAt(0).Value;
        //string user = principal.Identity.Name;
        var usr = await _userService.GetByEmailForAuthorize(user);

        if (usr == null || usr.RefreshToken != refreshToken || usr.RefreshTokenTime <= DateTime.Now)
        {
            return BadRequest("Invalid acess token/refresh token");
        }

        var newAcessToken = _tokenService.GenerateToKen(principal.Claims.ToList(), _configuration);

        var newRefreshToken = _tokenService.GenereteRefreshToken();

        usr.RefreshToken = newRefreshToken;

        await _userService.UpdateToken(usr);
        
        return Ok(new
        {
            acessToken = new JwtSecurityTokenHandler().WriteToken(newAcessToken),
            refreshToken = newRefreshToken
        });
    }
    
}