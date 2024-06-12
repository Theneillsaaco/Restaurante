using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Core;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Extentions;

namespace Restaurante.Infrastructure.Repository;

public class DetallePedidoRepository : BaseRepository<DetallePedido>, IDetallePedidoRepository
{
    #region MyRegion

    private readonly RestauranteDBContext _context;
    
    public DetallePedidoRepository(RestauranteDBContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public override async Task Save(DetallePedido entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Detalle del Pedido no Puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("El Detalle del Pedido no puede ser null.");

        if (!await base.Exists(cd => cd.IdPedido == entity.IdPedido))
            throw new DetallePedidoException("El Detalle del Pedido ya existe");

        await base.Save(entity);
    }
    
    public async Task<List<DetallePedidoMenuModel>> GetDetallePedido()
    {
        var detallePedido = _context.DetallePedidos
            .Join(_context.Pedidos,
                dep => dep.IdPedido,
                ped => ped.IdPedido,
                (dep, ped) => dep.ConvertDetallePedidoEntityToDetallePedidoMenuModel(ped))
            .Join(_context.Menus,
                dep => dep.IdPlato,
                men => men.IdPlato,
                (ped, men) => new DetallePedidoMenuModel()
                {
                    IdPlato = men.IdPlato
                })
            .ToListAsync();

        return await detallePedido;
    }

    public async Task<List<DetallePedidoMenuModel>> GetDetallePedidoByPedidoAndMenu(int idPedido, int idPlato)
    {
        var detallePedido = _context.DetallePedidos
            .Where(dep => dep.IdPedido == idPedido
                        && dep.IdPlato == idPlato)
            .Join(_context.Pedidos,
                dep => dep.IdPedido,
                ped => ped.IdPedido,
                (dep, ped) => dep.ConvertDetallePedidoEntityToDetallePedidoMenuModel(ped))
            .Join(_context.Menus,
                dep => dep.IdPlato,
                men => men.IdPlato,
                (ped, men) => new DetallePedidoMenuModel()
                {
                    IdPlato = men.IdPlato
                })
            .ToListAsync();

        return await detallePedido;
    }
}