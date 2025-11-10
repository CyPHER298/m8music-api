using System.ComponentModel.DataAnnotations;
using M8MusicAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace M8MusicAPI.Infrastructure.Persistence.Models;

[Index(nameof(Cliente), nameof(Music), IsUnique = true)]
public class Avaliacao
{
    [Key] public Guid IdAvalicao { get; set; } = Guid.NewGuid();
    public Music Music { get; set; } = default!;
    [Required] public Guid IdMusic { get; set; }
    public Cliente Cliente { get; set; } = default!;
    [Required] public Guid ClienteId { get; set; }
    [Required] public int Nota { get; set; }
}