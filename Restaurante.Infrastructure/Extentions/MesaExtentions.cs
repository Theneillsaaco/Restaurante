using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Extentions;

public static class MesaExtentions
{
    public static MesaModel ConvertMesaEntityToMesaModel(this Mesa mesa)
    {
        MesaModel mesaModel = new MesaModel()
        {
            IdMesa = mesa.IdMesa,
            Capacidad = mesa.Capacidad,
            Estado = mesa.Estado
        };

        return mesaModel;
    }
}