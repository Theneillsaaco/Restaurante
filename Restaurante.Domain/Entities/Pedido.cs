using System.ComponentModel.DataAnnotations;

namespace Restaurante.Domain.Entities;

public partial class Pedido
{
    [Key]
    public int IdPedido { get; set; }

    public int? IdCliente { get; set; }

    public int? IdMesa { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Cliente IdClienteNavigation { get; set; }

    public virtual Mesa IdMesaNavigation { get; set; }
}