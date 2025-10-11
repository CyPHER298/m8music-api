namespace M8MusicAPI.DTOs;

public class AvaliacaoUpdateDto
{
    public Guid IdAvaliacao { get; set; }
    public Guid IdMusic { get; set; }
    public Guid IdCliente { get; set; }
    public int Nota { get; set; }
    public Guid IdAvalicao { get; set; }
}