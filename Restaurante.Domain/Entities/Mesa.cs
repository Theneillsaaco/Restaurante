using System.ComponentModel.DataAnnotations;

namespace Restaurante.Domain.Entities;

public partial class Mesa
{
    [Key]
    public int IdMesa { get; set; }

    public int? Capacidad { get; set; }

    public string Estado { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}