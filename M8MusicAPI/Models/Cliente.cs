using System.ComponentModel.DataAnnotations;

namespace M8MusicAPI.Models;

public class Cliente
{
    [Key] public Guid idCliente { get; set; } = Guid.NewGuid();
    [Required, MaxLength(80)] public string nmCliente { get; set; } = default!;
    [Required] public int cpf { get; set; }
    public ICollection<Avaliacao> avaliacoes { get; set; } = new List<Avaliacao>();
}