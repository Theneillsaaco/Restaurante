using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Core;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Extentions;

namespace Restaurante.Infrastructure.Repository;

public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
{
    #region Context

    private readonly RestauranteDBContext _context;
    
    public PedidoRepository(RestauranteDBContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public override async Task Save(Pedido entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Pedido no Puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("El Pedido no puede ser null.");

        if (!await base.Exists(cd => cd.IdPedido == entity.IdPedido))
            throw new PedidoException("El Pedido ya existe");

        await base.Save(entity);
    }
    
    public async Task<List<PedidoClienteMesaModel>> GetPedido()
    {
        var pedido = _context.Pedidos
            .Join(_context.Clientes,
                ped => ped.IdCliente,
                cli => cli.IdCliente,
                (ped, cli) => ped.ConvertPedidoEntityToPedidoClienteMesaModel(cli))
            .Join(_context.Mesas,
                ped => ped.IdMesa,
                mesa => mesa.IdMesa,
                (ped, mesa) => new PedidoClienteMesaModel
                {
                    IdMesa = mesa.IdMesa
                })
            .ToListAsync();

        return await pedido;
    }

    public async Task<List<PedidoClienteMesaModel>> GetPedidoByClienteAndMesa(int idCliente, int idMesa)
    {
        var pedido = _context.Pedidos
            .Where(ped => ped.IdCliente == idCliente
                        && ped.IdMesa == idMesa)
            .Join(_context.Clientes,
                ped => ped.IdCliente,
                cli => cli.IdCliente,
                (ped, cli) => ped.ConvertPedidoEntityToPedidoClienteMesaModel(cli))
            .Join(_context.Mesas,
                ped => ped.IdMesa,
                mesa => mesa.IdMesa,
                (ped, mesa) => new PedidoClienteMesaModel
                {
                    IdMesa = mesa.IdMesa
                })
            .ToListAsync();

        return await pedido;
        
    }
}