using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Extentions;

public static class DetallePedidoExtention
{
    public static DetallePedidoMenuModel ConvertDetallePedidoEntityToDetallePedidoMenuModel(this DetallePedido detallePedido, Pedido pedido)
    {
        DetallePedidoMenuModel detallePedidoMenuModel = new DetallePedidoMenuModel()
        {
            IdDetallePedido = detallePedido.IdDetallePedido,
            IdPedido = pedido.IdPedido,
            Cantidad = detallePedido.Cantidad,
            Subtotal = detallePedido.Subtotal
        };

        return detallePedidoMenuModel;
    }
}