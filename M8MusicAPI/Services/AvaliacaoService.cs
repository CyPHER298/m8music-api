using M8MusicAPI.DTOs;
using M8MusicAPI.Infrastructure.Persistence.Models;
using M8MusicAPI.Infrastructure.Persistence.Repository;
using M8MusicAPI.Models;
using M8MusicAPI.Repository;

namespace M8MusicAPI.Services;

public class AvaliacaoService : IAvaliacaoService
{
    private readonly IAvaliacaoRepository _avaliacaoRepository;

    public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
    {
        _avaliacaoRepository = avaliacaoRepository;
    }

    public Task<List<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoDto? dto = null)
    {
        var cliente = new Cliente { IdCliente = Guid.NewGuid(), NmCliente = "Henrique", Cpf = "123.123.123-12" };
        var musica = new Music
            { idMusic = Guid.NewGuid(), titulo = "Só Tu És Santo", artista = "MORADA", genre = "Gospel" };

        var avaliacoes = new List<Avaliacao>
        {
            new Avaliacao
            {
                IdAvalicao = Guid.NewGuid(),
                IdCliente = cliente.IdCliente,
                IdMusic = musica.idMusic,
                Nota = 5,
                Music = musica,
                Cliente = cliente
            },
            new Avaliacao
            {
                IdAvalicao = Guid.NewGuid(),
                IdCliente = cliente.IdCliente,
                IdMusic = musica.idMusic,
                Nota = 3,
                Music = musica,
                Cliente = cliente
            }
        };
        return Task.FromResult(avaliacoes);
    }

    public async Task<Avaliacao> SaveAvaliacaoAsync(Avaliacao avaliacao)
    {
        if (avaliacao == null)
        {
            throw new ArgumentNullException(nameof(avaliacao));
        }

        await _avaliacaoRepository.AddAsync(avaliacao);
        return avaliacao;
    }

    public async Task<bool> UpdateAvaliacaoAsync(AvaliacaoUpdateDto avaliacao)
    {
        var entity = await _avaliacaoRepository.GetByIdAsync(avaliacao.IdAvalicao);
        entity.Nota = avaliacao.Nota;
        entity.IdMusic = avaliacao.IdMusic;
        entity.IdCliente = avaliacao.IdCliente;
        
        _avaliacaoRepository.Update(entity);
        await _avaliacaoRepository.SaveChangesAsync();
        return true;
    }
}