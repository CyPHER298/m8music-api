namespace M8MusicAPI.Infrastructure.Persistence.Models;

public class LinkResource
{
    public string Href { get; set; } // O URL para a ação
    public string Rel { get; set; }  // O relacionamento (ex: "self", "update", "delete")
    public string Method { get; set; } // O método HTTP (ex: "GET", "PUT", "DELETE")
}