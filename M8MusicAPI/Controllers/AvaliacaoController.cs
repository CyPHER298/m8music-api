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
    private readonly LinkGenerator _linkGenerator;
    
    

    public AvaliacaoController(IAvaliacaoService avaliacaoService, IAvaliacaoRepository avaliacaoRepository)
    {
        _avaliacaoService = avaliacaoService;
        _avaliacaoRepository = avaliacaoRepository;
        _linkGenerator = _linkGenerator;
    }
    
    private AvaliacaoResourceDTO CriarLinksParaAvaliacao(AvaliacaoDto dto)
    {
        var resource = new AvaliacaoResourceDTO(dto);

        resource.Links.Add(new LinkResource
        {
            Href = _linkGenerator.GetUriByName(HttpContext, "GetAvaliacaoById", new { id = dto.IdAvaliacao }),
            Rel = "self",
            Method = "GET"
        });

        resource.Links.Add(new LinkResource
        {
            Href = _linkGenerator.GetUriByName(HttpContext, "AtualizarAvaliacao", new { id = dto.IdAvaliacao }),
            Rel = "update",
            Method = "PUT"
        });

        resource.Links.Add(new LinkResource
        {
            Href = _linkGenerator.GetUriByName(HttpContext, "DeletarAvaliacao", new { id = dto.IdAvaliacao }),
            Rel = "delete",
            Method = "DELETE"
        });
        
        resource.Links.Add(new LinkResource
        {
            Href = _linkGenerator.GetUriByName(HttpContext, "ListarAvaliacao", null),
            Rel = "collection",
            Method = "GET"
        });

        return resource;
    }

    [HttpGet(Name = "ListarAvaliacao")]
    public async Task<ActionResult<IEnumerable<AvaliacaoResourceDTO>>> ListarAvaliacao()
    {
        var avaliacoes = await _avaliacaoService.ListarAvaliacoesAsync();
        
        var dtoList = avaliacoes.Select(a => new AvaliacaoDto
        {
            IdAvaliacao = a.IdAvalicao, 
            IdCliente = a.ClienteId,
            IdMusic = a.IdMusic, 
            Nota = a.Nota
        }).ToList();
        
        var resourceList = dtoList.Select(CriarLinksParaAvaliacao).ToList();

        return Ok(resourceList);
    }
    
    [HttpGet("{id}", Name = "GetAvaliacaoById")]
    public async Task<ActionResult<AvaliacaoResourceDTO>> GetAvaliacaoById(Guid id) 
    {
        var avaliacao = await _avaliacaoRepository.GetByIdAsync(id); 
        if (avaliacao == null) return NotFound();

        // Mapear Avaliacao -> AvaliacaoDto
        var dto = new AvaliacaoDto 
        {
            IdAvaliacao = avaliacao.IdAvalicao, 
            IdCliente = avaliacao.ClienteId, 
            IdMusic = avaliacao.IdMusic, 
            Nota = avaliacao.Nota
        };
        
        var resource = CriarLinksParaAvaliacao(dto);
        return Ok(resource);
    }

    [HttpPost(Name = "CriarAvaliacao")] // <--- Nome da rota
    public async Task<ActionResult<AvaliacaoResourceDTO>> CriarAvaliacao([FromBody] AvaliacaoDto avaliacaoRequest)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        
        var entity = new Avaliacao
        {
            IdAvalicao = Guid.NewGuid(),
            ClienteId = avaliacaoRequest.IdCliente,
            IdMusic = avaliacaoRequest.IdMusic,
            Nota = avaliacaoRequest.Nota
        };
        
        var created = await _avaliacaoService.SaveAvaliacaoAsync(entity);
        var responseDto = new AvaliacaoDto()
        {
            IdAvaliacao = created.IdAvalicao,
            IdCliente = created.ClienteId,
            IdMusic = created.IdMusic,
            Nota = created.Nota
        };
        
        var resource = CriarLinksParaAvaliacao(responseDto);
        
        var selfLink = resource.Links.First(l => l.Rel == "self").Href;
        return Created(selfLink, resource); 
    }

    [HttpPut("{id}", Name = "AtualizarAvaliacao")]
    public async Task<IActionResult> AtualizarAvaliacao(Guid id, [FromBody] AvaliacaoUpdateDto dto)
    {
        if (dto.IdAvaliacao != id) return BadRequest("ID INVÁLIDO");
        var ok = await _avaliacaoService.UpdateAvaliacaoAsync(dto);
        if (!ok) return NotFound();
        return NoContent(); 
    }

    [HttpDelete("{id}", Name = "DeletarAvaliacao")]
    public async Task<IActionResult> DeletarAvaliacao(Guid id)
    {
        await _avaliacaoRepository.DeleteAsync(id);
        return NoContent();
    }
}