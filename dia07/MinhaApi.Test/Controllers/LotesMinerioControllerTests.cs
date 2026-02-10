using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Dtos;
using MinhaApi.Models;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LotesMinerioController : ControllerBase
{
    private readonly AppDbContext _context;

    public LotesMinerioController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? codigoLote,
        [FromQuery] StatusLote? status)
    {
        IQueryable<LoteMinerio> query = _context.LotesMinerio;

        if (!string.IsNullOrEmpty(codigoLote))
            query = query.Where(l => l.CodigoLote.Contains(codigoLote));

        if (status.HasValue)
            query = query.Where(l => l.Status == status.Value);

        var result = await query
            .Select(l => new LoteMinerioResponseDto
            {
                Id = l.Id,
                CodigoLote = l.CodigoLote,
                MinaOrigem = l.MinaOrigem,
                LocalizacaoAtual = l.LocalizacaoAtual,
                TeorFe = l.TeorFe,
                Umidade = l.Umidade,
                Toneladas = l.Toneladas,
                Status = l.Status
            })
            .ToListAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var lote = await _context.LotesMinerio.FindAsync(id);

        if (lote == null)
            return NotFound();

        return Ok(new LoteMinerioResponseDto
        {
            Id = lote.Id,
            CodigoLote = lote.CodigoLote,
            MinaOrigem = lote.MinaOrigem,
            LocalizacaoAtual = lote.LocalizacaoAtual,
            TeorFe = lote.TeorFe,
            Umidade = lote.Umidade,
            Toneladas = lote.Toneladas,
            Status = lote.Status
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLoteMinerioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.CodigoLote))
            return BadRequest("CodigoLote é obrigatório.");

        var lote = new LoteMinerio
        {
            CodigoLote = dto.CodigoLote,
            MinaOrigem = dto.MinaOrigem,
            LocalizacaoAtual = dto.LocalizacaoAtual,
            TeorFe = dto.TeorFe,
            Umidade = dto.Umidade,
            Toneladas = dto.Toneladas,
            Status = (StatusLote)dto.Status
        };

        _context.LotesMinerio.Add(lote);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = lote.Id }, lote);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateLoteMinerioDto dto)
    {
        var lote = await _context.LotesMinerio.FindAsync(id);

        if (lote == null)
            return NotFound("Lote não encontrado.");

        lote.LocalizacaoAtual = dto.LocalizacaoAtual;
        lote.Status = (StatusLote)dto.Status;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var lote = await _context.LotesMinerio.FindAsync(id);

        if (lote == null)
            return NotFound("Lote não encontrado.");

        _context.LotesMinerio.Remove(lote);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
