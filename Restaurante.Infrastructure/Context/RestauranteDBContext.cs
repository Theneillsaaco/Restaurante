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

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    #endregion
}