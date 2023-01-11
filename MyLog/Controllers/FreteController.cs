using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyLog.Data;
using MyLog.Data.Dtos;
using MyLog.Models;

namespace MyLog.Controllers;
[ApiController]
[Route("[controller]")]
public class FreteController : ControllerBase
{
    private LogContext _context;
    private IMapper _mapper;

    public FreteController(LogContext context, IMapper mapper = null)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Adicionafrete([FromBody] Frete frete)
    {        //frete frete = _mapper.Map<frete>(freteDto);

        _context.Fretes.Add(frete);       
        _context.SaveChanges();     
        return CreatedAtAction(nameof(RecuperafreteporId), new { id = frete.Id }, frete);
    }

    [HttpGet]
    public IActionResult Recuperafretes([FromQuery] int skip = 0, [FromQuery] int take = 500)
    {
        var fretes = _context.Fretes.Skip(skip).Take(take).ToList();
        return Ok(fretes);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperafreteporId(int id)
    {
        var frete = _context.Fretes.FirstOrDefault(frete => frete.Id == id);
        if (frete == null) return NotFound();
        return Ok(frete);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizafreteporId(int id, [FromBody] UpdateFreteDto freteDto)
    {
        Frete frete = _context.Fretes.FirstOrDefault(frete => frete.Id == id);
        if (frete == null) {
            return NotFound(); 
        }        
        _mapper.Map(freteDto, frete);
        _context.SaveChanges();
        return Ok(frete); 
    
        
    }

}


