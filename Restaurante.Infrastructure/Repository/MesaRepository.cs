using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Core;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Extentions;

namespace Restaurante.Infrastructure.Repository;

public class MesaRepository : BaseRepository<Mesa>, IMesaRepository
{
    #region context

    private readonly RestauranteDBContext _context;
    
    public MesaRepository(RestauranteDBContext context) : base(context)
    {
        _context = context;
    }
    
    #endregion

    public override async Task<Mesa> GetById(int id)
    {
        ArgumentNullException.ThrowIfNull(id, "El Id no puede ser null.");

        if (id == null)
            throw new ArgumentNullException("El id no puede ser null.");

        if (!await base.Exists(cd => cd.IdMesa == id))
            throw new MesaException("La mesa no existe");
        
        return await base.GetById(id);
    }
    
    public override async Task Save(Mesa entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La mesa no puede ser null.");

        if (entity is null)
            throw new ArgumentNullException(("La mesa no puede ser null."));

        if (await base.Exists(cd => cd.IdMesa == entity.IdMesa))
            throw new MesaException("La mesa ya existe.");

        await base.Save(entity);
    }

    public override async Task Update(Mesa entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "La mesa no puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("La Mesa no puede ser null.");

        if (!await base.Exists(cd => cd.IdMesa != entity.IdMesa))
            throw new MesaException("La mesa no existe");

        await base.Update(entity);
    }
    
    public async Task<List<MesaModel>> GetMesa()
    {
        var mesa = _context.Mesa
            .Select(mes => mes.ConvertMesaEntityToMesaModel())
            .ToListAsync();

        return await mesa;
    }
}