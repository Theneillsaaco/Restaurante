using Restaurante.Domain.Core.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Domain.Interfaces;

public interface IMesaRepository : IBaseRepository<Mesa>
{
    Task<List<MesaModel>> GetMesa();
}