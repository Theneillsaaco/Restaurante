using Restaurante.Domain.Core.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Domain.Interfaces;

public interface IDetallePedidoRepository : IBaseRepository<DetallePedido>
{
    Task<List<DetallePedidoMenuModel>> GetDetallePedido();

    Task<List<DetallePedidoMenuModel>> GetDetallePedidoByPedidoAndMenu(int idPedido, int idPlato);
}