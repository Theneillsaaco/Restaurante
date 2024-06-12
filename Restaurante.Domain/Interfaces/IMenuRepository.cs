using Restaurante.Domain.Core.Interfaces;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Domain.Interfaces;

public interface IMenuRepository : IBaseRepository<Menu>
{
    Task<List<MenuModel>> GetMenus();
}