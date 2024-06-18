using Restaurante.API.Models.MenuModels;
using Restaurante.Domain.Entities;

namespace Restaurante.API.Extentions;

public static class MenuViewExtencion
{
    public static Menu ConvertToEntityMenu(this MenuViewModel menuViewModel)
    {
        Menu menu = new Menu
        {
            IdPlato = menuViewModel.IdPlato,
            Nombre = menuViewModel.Nombre,
            Descripcion = menuViewModel.Descripcion,
            Precio = menuViewModel.Precio,
            Categoria = menuViewModel.Categoria
        };

        return menu;
    }
}