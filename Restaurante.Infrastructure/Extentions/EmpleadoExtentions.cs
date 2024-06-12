using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Extentions;

public static class EmpleadoExtentions
{
    public static EmpleadoModel ConvertEmpleadoEntityToEmpleadoModel(this Empleado empleado)
    {
        EmpleadoModel empleadoModel = new EmpleadoModel()
        {
            IdEmpleado = empleado.IdEmpleado,
            Nombre = empleado.Nombre,
            Cargo = empleado.Cargo
        };

        return empleadoModel;
    }
}