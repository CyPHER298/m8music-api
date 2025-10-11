using M8MusicAPI.Infrastructure.Persistence.Models;
using M8MusicAPI.Models;

namespace M8MusicAPI.DTOs;

public class AvaliacaoDto
{
    public Guid IdAvaliacao { get; set; }
    public Music Music { get; set; }
    public Guid IdMusic { get; set; }
    public Cliente Cliente { get; set; }
    public Guid IdCliente { get; set; }
    public int Nota { get; set; }
}