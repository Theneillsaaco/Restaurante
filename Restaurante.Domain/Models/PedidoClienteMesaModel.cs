namespace Restaurante.Domain.Models;

public class PedidoClienteMesaModel
{
    public int IdPedido { get; set; }

    public int? IdCliente { get; set; }
    
    public string? NombreCliente { get; set; }
    
    public int? IdMesa { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }
}