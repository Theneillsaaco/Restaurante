using Restaurante.Domain.Core.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Domain.Interfaces;

public interface IClienteRepository : IBaseRepository<Cliente>
{
    Task<List<ClienteModel>> GetClientes();
}