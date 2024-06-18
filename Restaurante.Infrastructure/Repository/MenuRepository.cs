using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Core;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Extentions;

namespace Restaurante.Infrastructure.Repository;

public class MenuRepository : BaseRepository<Menu>, IMenuRepository
{
    #region Context

    private readonly RestauranteDBContext _context;
    
    public MenuRepository(RestauranteDBContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public override async Task<Menu> GetById(int id)
    {
        ArgumentNullException.ThrowIfNull(id, "El id no puede ser null.");

        if (id == null)
            throw new ArgumentNullException("El id no puede ser null.");

        if (!await base.Exists(cd => cd.IdPlato == id))
            throw new MenuException("El Plato no existe.");

        return await base.GetById(id);
    }
    public override async Task Save(Menu entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Plato no Puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("El Plato no puede ser null.");

        if (await base.Exists(cd => cd.IdPlato == entity.IdPlato))
            throw new MenuException("El Plato ya existe.");

        await base.Save(entity);
    }

    public override async Task Update(Menu entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El plato no puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("El Plato no puede ser null.");

        await base.Update(entity);
    }
    
    public async Task<List<MenuModel>> GetMenus()
    {
        var menu = _context.Menu
            .Select(men => men.ConvertMenuEntityToMenuModel())
            .ToListAsync();

        return await menu;
    }
}