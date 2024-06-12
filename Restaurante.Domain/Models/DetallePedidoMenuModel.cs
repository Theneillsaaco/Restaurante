namespace Restaurante.Domain.Models;

public class DetallePedidoMenuModel
{
    public int IdDetallePedido { get; set; }
    
    public int? IdPedido { get; set; }

    public int? IdPlato { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }
}