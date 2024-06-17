using Restaurante.API.Models.ClienteModels;
using Restaurante.Domain.Entities;

namespace Restaurante.API.Extentions;

public static class ClienteViewExtencion
{
    public static Cliente ConvertToEntityCliente(this ClienteViewModel clienteViewModel)
    {
        Cliente cliente = new Cliente()
        {
            IdCliente = clienteViewModel.IdCliente,
            Nombre = clienteViewModel.Nombre,
            Telefono = clienteViewModel.Telefono,
            Email = clienteViewModel.Email
        };

        return cliente;
    }
}