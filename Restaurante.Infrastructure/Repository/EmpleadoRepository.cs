using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Core;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Extentions;

namespace Restaurante.Infrastructure.Repository;

public class EmpleadoRepository : BaseRepository<Empleado>, IEmpleadoRepository
{
    #region MyRegion

    private readonly RestauranteDBContext _context;
    
    public EmpleadoRepository(RestauranteDBContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public override async Task Save(Empleado entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Empleado no puedes er null.");

        if (entity is null)
            throw new ArgumentNullException("El Empleado no puede ser null");

        if (await base.Exists(cd => cd.IdEmpleado == entity.IdEmpleado))
            throw new EmpleadoException("El Empleado ya Exites");

        await base.Save(entity);
    }
    
    public async Task<List<EmpleadoModel>> GetEmpleado()
    {
        var empleado = _context.Empleado
            .Select(emp => emp.ConvertEmpleadoEntityToEmpleadoModel())
            .ToListAsync();

        return await empleado;
    }
}