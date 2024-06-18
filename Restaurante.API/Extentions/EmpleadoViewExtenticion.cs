using Restaurante.API.Models.EmpleadoModels;
using Restaurante.Domain.Entities;

namespace Restaurante.API.Extentions;

public static class EmpleadoViewExtenticion
{
    public static Empleado ConvertToEntityEmpleado(this EmpleadoViewModel empleadoViewModel)
    {
        Empleado empleado = new Empleado
        {
            IdEmpleado = empleadoViewModel.IdEmpleado,
            Nombre = empleadoViewModel.Nombre,
            Cargo = empleadoViewModel.Cargo
        };

        return empleado;
    }
}