using Restaurante.Domain.Core.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Domain.Interfaces;

public interface IFacturaRepository : IBaseRepository<Factura>
{
    Task<List<FacturaPedidoModel>> GetFactura();

    Task<List<FacturaPedidoModel>> GetFacturaByPedido(int idPedido);
}