using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Repository;

namespace Restaurante.Infrastructure.Unit.Test.RepositoryTest;

public class ClienteRepositoryTest
{
    private RestauranteDBContext _context = null;
    private readonly IClienteRepository clienteRepository;
    
    public ClienteRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<RestauranteDBContext>()
            .UseInMemoryDatabase("RestauranteDb")
            .Options;

        _context = new RestauranteDBContext(options);
        
        clienteRepository = new ClienteRepository(_context);
        
        #region Codigo de prueba

        List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente()
            {
                IdCliente = 1,
                Nombre = "Luz",
                Telefono = "555-555-5555",
                Email = "exaple@exaple.com"
            },
            new Cliente()
            {
                IdCliente = 2,
                Nombre = "Juan",
                Telefono = "829-000-0000",
                Email = "juan@exaple.com"
            },
        };

        clienteRepository.Save(clientes);

        #endregion

    }
    
    [Fact]
    public async Task GetClientes_WithValidClienteModel()
    {
        // Arrange

        var clientesTask = clienteRepository.GetClientes();
    
        // Act

        var clientes = await clientesTask;
        
        // Expect

        var clienteName = "Luz";
        var clienteTelefono = "555-555-5555";
        var clienteEmail = "exaple@exaple.com";

        // Assert

        Assert.NotNull(clientes);
        Assert.IsType<List<ClienteModel>>(clientes);
        Assert.True(clientes.Any());
        Assert.Equal(clienteName, clientes[0].Nombre);
        Assert.Equal(clienteTelefono, clientes[0].Telefono);
        Assert.Equal(clienteEmail, clientes[0].Email);
    }

    [Fact]
    public async Task Get_WithValidClienteModel()
    {
        // Arrange
        var idCliente = 1;
            
        var clienteTask = clienteRepository.Get(idCliente);

        // Act

        var cliente = await clienteTask;

        // Expect

        var clienteName = "Luz";
        var clienteTelefono = "555-555-5555";
        var clienteEmail = "exaple@exaple.com";

        // Assert
        
        Assert.NotNull(cliente);
        Assert.IsType<Cliente>(cliente);
        Assert.Equal(clienteName, cliente.Nombre);
        Assert.Equal(clienteTelefono, cliente.Telefono);
        Assert.Equal(clienteEmail, cliente.Email);
    }

    [Fact]
    public async Task Save_WithValidClienteModel()
    {
        // Arrange

        var newCliente = new Cliente()
        {
            Nombre = "Hola",
            Telefono = "829-000-000",
            Email = "hola@exaple.com"
        };

        // Act

        await clienteRepository.Save(newCliente);
        
        // Expect

        var savedCliente = _context.Cliente.FirstOrDefault(cd => 
                                                            cd.Nombre == newCliente.Nombre);
        
        // Assert
        
        Assert.NotNull(savedCliente);
        Assert.Equal(newCliente.Nombre, savedCliente.Nombre);
        Assert.Equal(newCliente.Telefono, savedCliente.Telefono);
        Assert.Equal(newCliente.Email, savedCliente.Email);
    }

    [Fact]
    public async Task Exists_ShouldReturnTrue_WhereMatchingClienteExists()
    {
        // Arrange
        
        var idCliente = 1;
        
        // Act

        var exists = await clienteRepository.Exists(cd => cd.IdCliente == idCliente);
        
        // Assert
        Assert.True(exists);
    }
    
    [Fact]
    public async Task Exists_ShouldReturnFalse_WhereMatchingClienteExists()
    {
        // Arrange
        
        var idCliente = 10;
        
        // Act

        var exists = await clienteRepository.Exists(cd => cd.IdCliente == idCliente);
        
        // Assert
        Assert.False(exists);
    }
}