using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Core;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Extentions;

namespace Restaurante.Infrastructure.Repository;

public class FacturaRepository : BaseRepository<Factura>, IFacturaRepository
{
    #region Context

    private readonly RestauranteDBContext _context;
    
    public FacturaRepository(RestauranteDBContext context) : base(context)
    {
        _context = context;
    }
    
    #endregion
    
    public override async Task Save(Factura entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La Factura no Puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("La Factura no puede ser null.");

        if (await base.Exists(cd => cd.IdFactura == entity.IdFactura))
            throw new FacturaException("La Factura ya existe");

        await base.Save(entity);
    }
    
    public async Task<List<FacturaPedidoModel>> GetFactura()
    {
        var factura = _context.Factura
            .Join(_context.Pedido,
                fac => fac.IdPedido,
                ped => ped.IdPedido,
                (fac, ped) => fac.ConvertFacturaEntityToFacturaPedidoModel(ped))
            .ToListAsync();

        return await factura;
    }

    public async Task<List<FacturaPedidoModel>> GetFacturaByPedido(int idPedido)
    {
        var factura = _context.Factura
            .Where(fac => fac.IdPedido == idPedido)
            .Join(_context.Pedido,
                fac => fac.IdPedido,
                ped => ped.IdPedido,
                (fac, ped) => fac.ConvertFacturaEntityToFacturaPedidoModel(ped))
            .ToListAsync();

        return await factura;
    }
}