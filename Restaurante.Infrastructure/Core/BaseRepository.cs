using Restaurante.Domain.Core.Interfaces;
using System.Linq.Expressions;
using Restaurante.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Restaurante.Infrastructure.Core;

/// <summary>
/// Clase Base de los Repository.
/// </summary>
/// <typeparam name="TEntity">Cambiar "TEntity" por su Clase.</typeparam>
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    #region"Context"

    private readonly RestauranteDBContext _context;
    private readonly DbSet<TEntity> _entities;

    protected BaseRepository(RestauranteDBContext context)
    {
        this._context = context;
        this._entities = context.Set<TEntity>();
    }

    #endregion
    
    public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
    {
        return await _entities.Where(filter).ToListAsync();
    }

    public virtual async Task<TEntity> Get(int id)
    {
        return await _entities.FindAsync(id);
    }

    public virtual async Task Save(TEntity entity)
    {
        this._entities.Add(entity);
        await _context.SaveChangesAsync();

    }

    public virtual async Task Save(List<TEntity> entities)
    {
        this._entities.AddRange(entities);
        await _context.SaveChangesAsync();
    }
  
    public virtual async Task Update(TEntity entity)
    {
        this._entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task Update(List<TEntity> entities)
    {
        this._entities.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public virtual Task Delete(TEntity entity)
    {
        this._entities.Remove(entity);
        return _context.SaveChangesAsync();
    }

    public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
    {
        return await _entities.AnyAsync(filter);
    }
}