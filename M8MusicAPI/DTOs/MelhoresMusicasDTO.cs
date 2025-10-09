namespace M8MusicAPI.DTOs;

public record MelhoresMusicasDTO(
    Guid idMusica,
    string titulo,
    string artista,
    int Avaliacoes,
    double Media);