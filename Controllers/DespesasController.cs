using financas.Models.DTO;
using financas.Request;
using financas.Services;
using financas.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace financas.Controllers;

[ApiController]
[Route("api/despesas")]
public class DespesasController : ControllerBase
{

    private readonly IDespesasService _despesasServices;

    public DespesasController(IDespesasService despesasService)
    {
        _despesasServices = despesasService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var despAll = await _despesasServices.GetAllAsync();
            return Ok(despAll);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new {status= "Não foi possivel listar as despesas", message= ex.Message });
        }

    }
    
    [HttpPost]
    public async Task<IActionResult> Insert([FromBody]DespesasDTO despe)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var insertDesp = await _despesasServices.Insert(despe);
            return Ok(insertDesp);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { status = "Não foi possível criar a despesas", message = ex.Message });
        }
    }

    [HttpGet ("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        try
        {
            var desp = await _despesasServices.GetDespesa(id);
            return Ok(desp);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { status = "Não foi possível consultar a despesa", message = e.Message });
        }
    }

    [HttpGet("paginate")]
    public async Task<IActionResult> GetPaginate([FromQuery] FilterRequest filter)
    {
        try
        {
            var desp =  await _despesasServices.GetDespesaPaginate(filter);
            var response = new
            {
                desp.CurrentPage,
                desp.PageSize,
                desp.TotalCount,
                desp.HasNext,
                desp.HasPrevious,
                desp.Items
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { status = "Não foi possível consultar a despesa", message = e.Message });
        }
    }
}
