using Restaurante.Domain.Core.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Domain.Interfaces;

public interface IEmpleadoRepository : IBaseRepository<Empleado>
{
    Task<List<EmpleadoModel>> GetEmpleado();
}