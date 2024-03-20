using financas.Models.DTO;
using financas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace financas.Controllers;
[ApiController]
[Route("api/pessoas")]
public class PessoasController: ControllerBase
{
    private readonly IPessoasService _pessoasService;

    public PessoasController(IPessoasService pessoasService)
    {
        _pessoasService = pessoasService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        try
        {
            var pes = await _pessoasService.GetById(id);
            return Ok(pes);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { result = "Não foi possivel encontar a pessoa", message = e.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] PessoasDTO pes)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var pesd = await _pessoasService.Insert(pes);
            return Ok(pesd);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { result = "Nao foi possivel inserir a pessoa", message = e.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var pes = await _pessoasService.GetAllAsync();
            return Ok(pes);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { result = "Nao foi possivel listar as pessoas", message = e.Message });
        }
    }
}