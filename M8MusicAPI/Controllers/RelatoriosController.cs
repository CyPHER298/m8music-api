using M8MusicAPI.Data;
using M8MusicAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace M8MusicAPI.Controllers;

[Route("api/relatorios")]
[ApiController]
[SwaggerTag("Relatórios das avaliações das músicas")]
public class RelatoriosController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public RelatoriosController(AppDbContext dbContext) => _dbContext = dbContext;

    [HttpGet]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]

    public IActionResult mostrarRelatorios()
    {
        return Ok("CERTO");
    }

    [HttpGet("melhores")]
    public async Task<ActionResult<IEnumerable<MelhoresMusicasDTO>>> RelatoriosMelhores(
        [FromQuery] int top = 10)
    {
        var query = _dbContext.Avaliacoes.AsQueryable();
        var result =  query
            .GroupBy(a => new { a.idMusic, a.music.titulo, a.music.artista })
            .Select(g => new MelhoresMusicasDTO(
                g.Key.idMusic,
                g.Key.titulo,
                g.Key.artista,
                g.Count(),
                g.Average(a => a.nota)
            ))
            .OrderByDescending(x => x.Media)
            .ThenByDescending(x => x.Avaliacoes)
            .Take(top);
        return Ok(result);
    }
}