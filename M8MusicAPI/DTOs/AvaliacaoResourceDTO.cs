using System.Text.Json.Serialization;
using M8MusicAPI.Infrastructure.Persistence.Models;

namespace M8MusicAPI.DTOs;

public class AvaliacaoResourceDTO
{
    [JsonPropertyOrder(-1)] 
    public List<LinkResource> Links { get; set; } = new List<LinkResource>();
    public Guid IdAvaliacao { get; set; }
    public Guid IdCliente { get; set; }
    public Guid IdMusic { get; set; }
    public int Nota { get; set; }

    public AvaliacaoResourceDTO() { }
    
    public AvaliacaoResourceDTO(AvaliacaoDto dto)
    {
        IdAvaliacao = dto.IdAvaliacao;
        IdCliente = dto.IdCliente;
        IdMusic = dto.IdMusic;
        Nota = dto.Nota;
    }
}