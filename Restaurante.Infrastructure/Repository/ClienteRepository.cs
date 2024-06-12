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
        this._context = context;
    }

    #endregion

    public override async Task Save(Cliente entity)
    {
        ArgumentNullException.ThrowIfNull(entity, "El Cliente no puede ser null.");

        if (entity is null)
            throw new ArgumentNullException("El Cliente no puede ser null.");
        
        if (!await base.Exists(cd => cd.IdCliente == entity.IdCliente))
            throw new ClienteException("El Cliente ya Existe.");

        await base.Save(entity);
    }

    public async Task<List<ClienteModel>>  GetClientes()
    {
        var cliente = _context.Clientes
            .Select(cli => cli.ConvertClienteEntityToClienteModel())
            .ToListAsync();

        return await cliente;
    }
}