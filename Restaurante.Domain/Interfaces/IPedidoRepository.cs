using Restaurante.Domain.Core.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Domain.Interfaces;

public interface IPedidoRepository : IBaseRepository<Pedido>
{
    Task<List<PedidoClienteMesaModel>> GetPedido();

    Task<List<PedidoClienteMesaModel>> GetPedidoByClienteAndMesa(int idCliente, int idMesa);
}