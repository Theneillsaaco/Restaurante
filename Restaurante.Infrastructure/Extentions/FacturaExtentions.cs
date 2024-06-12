using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Extentions;

public static class FacturaExtentions
{
    public static FacturaPedidoModel ConvertFacturaEntityToFacturaPedidoModel(this Factura factura, Pedido pedido)
    {
        FacturaPedidoModel facturaPedidoModel = new FacturaPedidoModel()
        {
            IdFactura = factura.IdFactura,
            IdPedido = pedido.IdPedido,
            Total = factura.Total,
            Fecha = factura.Fecha
        };

        return facturaPedidoModel;
    }
}