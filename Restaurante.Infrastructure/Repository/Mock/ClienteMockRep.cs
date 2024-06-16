using System.Linq.Expressions;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Repository.Mock;

public class ClienteMockRep : IClienteRepository
{
    private List<Cliente> clientes;

    public ClienteMockRep()
    {
        this.clientes = new List<Cliente>();
    }
    
    public Task<List<Cliente>> GetAll(Expression<Func<Cliente, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task Save(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public Task Save(List<Cliente> entities)
    {
        throw new NotImplementedException();
    }

    public Task Update(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(List<Cliente> entities)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(Expression<Func<Cliente, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<ClienteModel>> GetClientes()
    {
        throw new NotImplementedException();
    }
}