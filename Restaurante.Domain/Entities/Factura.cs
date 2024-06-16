using System.ComponentModel.DataAnnotations;

namespace Restaurante.Domain.Entities;

public partial class Factura
{
    [Key]
    public int IdFactura { get; set; }
    
    public int? IdPedido { get; set; }

    public decimal? Total { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; }
}