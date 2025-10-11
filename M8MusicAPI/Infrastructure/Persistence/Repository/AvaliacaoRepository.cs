using M8MusicAPI.Data;
using M8MusicAPI.Infrastructure.Persistence.Models;
using M8MusicAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace M8MusicAPI.Infrastructure.Persistence.Repository;

public class AvaliacaoRepository(AppDbContext context) : IAvaliacaoRepository
{

    public async Task AddAsync(Avaliacao avaliacao)
    {
        context.Avaliacoes.Add(avaliacao);
        await context.SaveChangesAsync();
    }
    public async Task<List<Avaliacao>> GetAllAsync()
    {
        return await context.Avaliacoes.ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var avaliacao = await context.Avaliacoes.FindAsync(id);
        
        if (avaliacao is not null)
            context.Avaliacoes.Remove(avaliacao);
        await context.SaveChangesAsync();
    }

    public async Task<Avaliacao> GetByIdAsync(Guid id)
    {
        return await context.Avaliacoes.FindAsync(id);
    }

    public void Update(Avaliacao entity)
    {
        context.Avaliacoes.Update(entity);
    }

    public Task<int> SaveChangesAsync()
    {
        return context.SaveChangesAsync();
    }

}