using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;

namespace Restaurante.Infrastructure.Context;

public partial class RestauranteDBContext : DbContext
{
    public RestauranteDBContext(DbContextOptions<RestauranteDBContext> options)
        : base(options)
    {
    }

    #region"Entities"

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetallePedido> DetallePedido { get; set; }

    public virtual DbSet<Empleado> Empleado { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Menu> Menu { get; set; }

    public virtual DbSet<Mesa> Mesa { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    #endregion
}