using Restaurante.Domain.Core.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Domain.Entities;

public partial class Cliente : Person
{
    [Key]
    public int IdCliente { get; set; }

    [Phone]
    public string Telefono { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}