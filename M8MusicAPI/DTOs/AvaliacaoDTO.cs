using M8MusicAPI.Infrastructure.Persistence.Models;
using M8MusicAPI.Models;

namespace M8MusicAPI.DTOs;

public record AvaliacaoDto(
    Guid IdAvalicao,
    Music Music,
    Guid IdMusic,
    Cliente Cliente,
    Guid IdCliente,
    int Nota
    );