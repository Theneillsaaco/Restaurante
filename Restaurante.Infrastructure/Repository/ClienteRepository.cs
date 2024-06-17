using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Core;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Extentions;

namespace Restaurante.Infrastructure.Repository;

public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
{
    #region Context

    private readonly RestauranteDBContext _context;
    
    public ClienteRepository(RestauranteDBContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    public override async Task<Cliente> GetById(int id)
    {
        ArgumentNullException.ThrowIfNull(id, "El Id no puede ser null.");

        if (id == null)
            throw new ArgumentNullException("El Id no puede ser null.");

        if (!await base.Exists(cd => cd.IdCliente == id))
            throw new ClienteException("El cliente no existe.");

        return await base.GetById(id);
    }
    
    public override async Task Save(Cliente entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Cliente no puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("El Cliente no puede ser null.");
        
        if (await base.Exists(cd => cd.IdCliente == entity.IdCliente))
            throw new ClienteException("El Cliente ya Existe.");
        
        
        await base.Save(entity);
    }

    public override async Task Update(Cliente entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El cliente no puede ser null.");
        
        if (entity is null)
            throw new ArgumentNullException("El Cliente no puede ser null.");
        
        if (!await base.Exists(cd => cd.IdCliente != entity.IdCliente))
            throw new ClienteException("El Cliente no Existe.");

        await base.Update(entity);
    }

    public override async Task Update(List<Cliente> entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El cliente no puede ser null.");
        
        if (entity is null)
            throw new ArgumentNullException("El Cliente no puede ser null.");

        if (!entity.Any())
            throw new ClienteException("debe proporcionar por lo menos un cliente en la lista.");
        
        await base.Update(entity);
    }

    public async Task<List<ClienteModel>> GetClientes()
    {
        var cliente = _context.Cliente
            .Select(cli => cli.ConvertClienteEntityToClienteModel())
            .ToListAsync();

        return await cliente;
    }
}