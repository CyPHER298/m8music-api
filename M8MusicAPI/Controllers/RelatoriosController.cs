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
    
}