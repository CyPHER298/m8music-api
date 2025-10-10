using System.ComponentModel.DataAnnotations;

namespace M8MusicAPI.Infrastructure.Persistence.Models;

public class Cliente
{
    [Key] public Guid IdCliente { get; set; } = Guid.NewGuid();
    [Required, MaxLength(80)] public string NmCliente { get; set; } = default!;
    [Required, MaxLength(14)] public string Cpf { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
}