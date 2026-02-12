using Microsoft.AspNetCore.Mvc;
using MinhaApi.Services;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api/lotes-extras")]
public class LotesExtrasController : ControllerBase
{
    private readonly LoteService _service;

    public LotesExtrasController(LoteService service)
    {
        _service = service;
    }

    [HttpGet("classificacao/{id}")]
    public IActionResult Classificacao(int id)
        => Ok(_service.ClassificarQualidade(id));

    [HttpGet("preco/{id}")]
    public IActionResult Preco(int id)
        => Ok(_service.CalcularPreco(id));

    [HttpGet("penalidade/{id}")]
    public IActionResult Penalidade(int id)
        => Ok(_service.CalcularPenalidade(id));

    [HttpPost("movimentacao/{id}")]
    public IActionResult Movimentacao(int id)
        => Ok(_service.RegistrarMovimentacao(id));

    [HttpPost("avancar-status/{id}")]
    public IActionResult AvancarStatus(int id)
        => Ok(_service.AvancarStatus(id));
}
