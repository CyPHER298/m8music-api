using M8MusicAPI.Infrastructure.Persistence.Models;

namespace M8MusicAPI.Infrastructure.Persistence.Repository;

public interface IAvaliacaoRepository
{
    Task<List<Avaliacao>> GetAllAsync();
    Task AddAsync(Avaliacao avaliacao);
    Task DeleteAsync(Guid id);
    Task<Avaliacao> GetByIdAsync(Guid id);
    void Update(Avaliacao entity);
    Task<int> SaveChangesAsync();
}