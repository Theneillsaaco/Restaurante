namespace Restaurante.Domain.Models;

public class MesaModel
{
    public int IdMesa { get; set; }
    
    public int? Capacidad { get; set; }
    
    public string Estado { get; set; }
}