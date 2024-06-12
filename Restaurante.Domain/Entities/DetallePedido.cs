using System.ComponentModel.DataAnnotations;

namespace Restaurante.Domain.Entities;

public partial class DetallePedido
{
    [Key]
    public int IdDetallePedido { get; set; }

    [Key]
    public int? IdPedido { get; set; }

    [Key]
    public int? IdPlato { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; }

    public virtual Menu IdPlatoNavigation { get; set; }
}