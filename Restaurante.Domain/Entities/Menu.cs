using Restaurante.Domain.Core.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Domain.Entities;

public partial class Menu : Person
{
    [Key]
    public int IdPlato { get; set; }

    public string Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string Categoria { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();
}