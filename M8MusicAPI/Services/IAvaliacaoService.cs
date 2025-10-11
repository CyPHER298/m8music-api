using M8MusicAPI.DTOs;
using M8MusicAPI.Infrastructure.Persistence.Models;
using M8MusicAPI.Models;

namespace M8MusicAPI.Services;

public interface IAvaliacaoService
{
    Task<List<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoDto? dto = null);
    Task<Avaliacao> SaveAvaliacaoAsync(Avaliacao avaliacao);
    Task<bool> UpdateAvaliacaoAsync(AvaliacaoUpdateDto avaliacao);
}