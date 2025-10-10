using M8MusicAPI.DTOs;
using M8MusicAPI.Infrastructure.Persistence.Models;
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

    public Task<List<Avaliacao>> ListarAvaliacoesAsync(AvaliacaoDto dto)
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

    public Task<List<Avaliacao>> listarAvaliacoesAsync()
    {
        throw new NotImplementedException();
    }
}