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
    private readonly UserManager<Usuarios> _userManager;

    public AuthController(ITokenService tokenService, IConfiguration configuration, UserManager<Usuarios> userManager)
    {
        _tokenService = tokenService;
        _configuration = configuration;
        _userManager = userManager;
    }
    
}