using Restaurante.Domain.Entities;
using Restaurante.Domain.Models;

namespace Restaurante.Infrastructure.Extentions;

public static class ClienteExtentions
{
    public static ClienteModel ConvertClienteEntityToClienteModel(this Cliente cliente)
    {
        ClienteModel clienteModel = new ClienteModel()
        {
            IdCliente = cliente.IdCliente,
            Nombre = cliente.Nombre,
            Telefono = cliente.Telefono,
            Email = cliente.Email
        };

        return clienteModel;
    }
}