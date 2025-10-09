using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace M8MusicAPI.Models;

[Index(nameof(cliente), nameof(music), IsUnique = true)]
public class Avaliacao
{
    [Key] public Guid idAvalicao { get; set; } = Guid.NewGuid();
    public Music music { get; set; } = default!;
    [Required] public Guid idMusic { get; set; }
    public Cliente cliente { get; set; } = default!;
    [Required] public Guid idCliente { get; set; }
    [Required] public int nota { get; set; }
}