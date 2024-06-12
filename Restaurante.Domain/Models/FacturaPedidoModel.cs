namespace Restaurante.Domain.Models;

public class FacturaPedidoModel
{
    public int IdFactura { get; set; }
    
    public int? IdPedido { get; set; }

    public decimal? Total { get; set; }

    public DateOnly? Fecha { get; set; }
}