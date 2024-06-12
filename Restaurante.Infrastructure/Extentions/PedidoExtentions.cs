using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Extentions;

public static class PedidoExtentions
{
    public static PedidoClienteMesaModel ConvertPedidoEntityToPedidoClienteMesaModel(this Pedido pedido, Cliente cliente)
    {
        PedidoClienteMesaModel pedidoClienteMesaModel = new PedidoClienteMesaModel()
        {
            IdPedido = pedido.IdPedido,
            IdCliente = pedido.IdCliente,
            NombreCliente = cliente.Nombre,
            Fecha = pedido.Fecha,
            Total = pedido.Total
        };

        return pedidoClienteMesaModel;
    }
}