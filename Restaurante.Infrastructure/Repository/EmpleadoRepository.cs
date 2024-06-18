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


    public override async Task<Empleado> GetById(int id)
    {
        ArgumentNullException.ThrowIfNull(id, "El id no puede ser null");

        if (id == null)
            throw new ArgumentNullException("El id no puede ser null.");

        if (!await base.Exists(cd => cd.IdEmpleado == id))
            throw new EmpleadoException("El Empleado no existe.");

        return await base.GetById(id);
    }
    public override async Task Save(Empleado entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Empleado no puedes er null.");

        if (entity is null)
            throw new ArgumentNullException("El Empleado no puede ser null");

        if (await base.Exists(cd => cd.IdEmpleado == entity.IdEmpleado))
            throw new EmpleadoException("El Empleado ya Exites");

        await base.Save(entity);
    }

    public override async Task Update(Empleado entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Empleado no puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("El empleado no puede ser null.");

        if (await base.Exists(cd => cd.IdEmpleado != entity.IdEmpleado))
            throw new ClienteException("El no Existe");

        await base.Update(entity);
    }
    public async Task<List<EmpleadoModel>> GetEmpleado()
    {
        var empleado = _context.Empleado
            .Select(emp => emp.ConvertEmpleadoEntityToEmpleadoModel())
            .ToListAsync();

        return await empleado;
    }
}