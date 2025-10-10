using M8MusicAPI.Data;
using M8MusicAPI.DTOs;
using M8MusicAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace M8MusicAPI.Controllers;

[Route("api/relatorios")]
[ApiController]
[SwaggerTag("Relatórios das avaliações das músicas")]
public class RelatoriosController : ControllerBase
{
    private readonly IAvaliacaoService _avaliacaoService;

    public RelatoriosController(IAvaliacaoService avaliacaoService)
    {
        _avaliacaoService = avaliacaoService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> MostrarRelatorios()
    {
        var avaliacoes =
            await _avaliacaoService.ListarAvaliacoesAsync(null); // ajuste a assinatura do service, ver Opção 1 abaixo
        return Ok(new
        {
            total = avaliacoes.Count,
            items = avaliacoes.Select(a => new
            {
                a.IdAvalicao,
                a.Nota,
                music = new { a.Music.idMusic, a.Music.titulo, a.Music.artista, a.Music.genre },
                client = new { a.Cliente.IdCliente, a.Cliente.NmCliente }
            })
        });
    }

    [HttpGet]
    [Route("top-songs")]
    public IActionResult MostrarTopSongs()
    {
        return Ok();
    }

    [HttpGet]
    [Route("top-genres")]
    public IActionResult mostrarTopGenres()
    {
        return Ok();
    }

    [HttpGet]
    [Route("most-rated")]
    public IActionResult mostRated()
    {
        return Ok();
    }
}