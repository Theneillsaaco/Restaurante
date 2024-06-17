using Restaurante.API.Models.MesaModels;
using Restaurante.Domain.Entities;

namespace Restaurante.API.Extentions;

public static class MesaViewExtencion
{
    public static Mesa ConvertToEntityMesa(this MesaViewModel mesaViewModel)
    {
        Mesa mesa = new Mesa()
        {
            IdMesa = mesaViewModel.IdMesa,
            Capacidad = mesaViewModel.Capacidad,
            Estado = mesaViewModel.Estado

        };

        return mesa;
    }
}