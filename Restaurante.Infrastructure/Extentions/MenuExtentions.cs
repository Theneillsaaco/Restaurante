using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Extentions;

public static class MenuExtentions
{
    public static MenuModel ConvertMenuEntityToMenuModel(this Menu menu)
    {
        MenuModel menuModel = new MenuModel()
        {
            IdPlato = menu.IdPlato,
            Descripcion = menu.Descripcion,
            Precio = menu.Precio,
            Categoria = menu.Categoria
        };

        return menuModel;
    }
}