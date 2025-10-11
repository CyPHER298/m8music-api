using M8MusicAPI.DTOs;
using M8MusicAPI.Infrastructure.Persistence.Models;
using M8MusicAPI.Infrastructure.Persistence.Repository;
using M8MusicAPI.Repository;
using M8MusicAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace M8MusicAPI.Controllers;

[Route("api/avaliacao")]
[ApiController]
public class AvaliacaoController : ControllerBase
{
    private readonly IAvaliacaoService _avaliacaoService;
    private readonly IAvaliacaoRepository _avaliacaoRepository;

    public AvaliacaoController(IAvaliacaoService avaliacaoService, IAvaliacaoRepository avaliacaoRepository)
    {
        _avaliacaoService = avaliacaoService;
        _avaliacaoRepository = avaliacaoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Avaliacao>>> ListarAvaliacao()
    {
        return await _avaliacaoRepository.GetAllAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Avaliacao>> CriarAvaliacao([FromBody] AvaliacaoDto avaliacaoRequest)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        
        var entity = new Avaliacao
        {
            IdAvalicao = Guid.NewGuid(),
            IdCliente = avaliacaoRequest.IdCliente,
            IdMusic = avaliacaoRequest.IdMusic,
            Nota = avaliacaoRequest.Nota
        };
        
        var created = await _avaliacaoService.SaveAvaliacaoAsync(entity);
        var response = new AvaliacaoDto()
        {
            IdAvaliacao = created.IdAvalicao,
            IdCliente = created.IdCliente,
            IdMusic = created.IdMusic,
            Nota = created.Nota
        };
        return Created($"api/avaliacao/{created.IdAvalicao}", response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarAvaliacao(Guid id, [FromBody] AvaliacaoUpdateDto dto)
    {
        if (dto.IdAvaliacao != id) return BadRequest("ID INVÁLIDO");
        var ok = await _avaliacaoService.UpdateAvaliacaoAsync(dto);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarAvaliacao(Guid id)
    {
        await _avaliacaoRepository.DeleteAsync(id);
        return NoContent();
    }
}