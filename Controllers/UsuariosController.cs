using financas.Models.DTO;
using financas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financas.Controllers;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController:ControllerBase
{
    private readonly IUsuariosService _usuariosService;

    public UsuariosController(IUsuariosService usuariosService)
    {
        _usuariosService = usuariosService;
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] UsuariosDTO usrs)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await _usuariosService.Insert(usrs);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { status = "Não foi possível criar o usuário", message = e.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        try
        {
            var user = await _usuariosService.GetById(id);
            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { status = "Não foi possível obter o usuário", message = e.Message });
        }
    }
}