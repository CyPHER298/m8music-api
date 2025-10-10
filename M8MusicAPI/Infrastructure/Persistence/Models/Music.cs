using System.ComponentModel.DataAnnotations;
using M8MusicAPI.Infrastructure.Persistence.Models;

namespace M8MusicAPI.Models;

public class Music
{
    [Key] public Guid idMusic { get; set; } = Guid.NewGuid();
    [Required] public string titulo { get; set; } = default!;
    [Required] public string artista { get; set; } = default!;
    [Required] public string genre { get; set; } = default!;
    public ICollection<Avaliacao> avaliacoes { get; set; } = new List<Avaliacao>();
}