using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLog.Data;
using MyLog.Models;

namespace MyLog.Controllers;

[ApiController]
[Route("[controller]")]
public class VeiculoController : ControllerBase
{
    private LogContext _context;
    private IMapper _mapper;

    public VeiculoController(LogContext context, IMapper mapper = null)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaVeiculo([FromBody] Veiculo veiculo)
    {
        //Veiculo veiculo = _mapper.Map<Veiculo>(VeiculoDto);
        _context.Veiculos.Add(veiculo);       
        _context.SaveChanges();     
        return CreatedAtAction(nameof(RecuperaVeiculoporId), new { id = veiculo.Id }, veiculo);
    }

    [HttpGet]
    public IActionResult RecuperaVeiculos([FromQuery] int skip = 0, [FromQuery] int take = 500)
    {
        var veiculos = _context.Veiculos.Skip(skip).Take(take).ToList();
        return Ok(veiculos);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaVeiculoporId(int id)
    {
        var veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (veiculo == null) return NotFound();
        return Ok(veiculo);
    }

}


