using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces;
using Restaurante.Domain.Models;
using Restaurante.Infrastructure.Context;
using Restaurante.Infrastructure.Exceptions;
using Restaurante.Infrastructure.Repository;

namespace Restaurante.Infrastructure.Unit.Test.RepositoryTest;

public class ClienteRepositoryTest
{
    private RestauranteDBContext _context = null;
    private IClienteRepository clienteRepository;
    
    public ClienteRepositoryTest()
    {
        var options = new DbContextOptionsBuilder<RestauranteDBContext>()
            .UseInMemoryDatabase("RestauranteDb")
            .Options;

        _context = new RestauranteDBContext(options);
        
        clienteRepository = new ClienteRepository(_context);
        
        #region Entidades de prueba

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
    
    /// <summary>
    /// Para resetiar la base de datos por si se esta teniendo poblemas en los test
    /// </summary>
    public void ResetDatabase()
    {
        var options = new DbContextOptionsBuilder<RestauranteDBContext>()
            .UseInMemoryDatabase("RestauranteDb")
            .Options;
        
        
        _context.Database.EnsureDeleted();
        _context = new RestauranteDBContext(options);
        clienteRepository = new ClienteRepository(_context);
    }
    
    [Fact]
    public async Task GetClientes_WithValidClienteModel()
    {
        ResetDatabase();
        
        var newCliente = new Cliente()
        {
            IdCliente = -1,
            Nombre = "Luz",
            Telefono = "555-555-5555",
            Email = "exaple@exaple.com"
            
        };
    
        await clienteRepository.Save(newCliente);

        var clientesTask = clienteRepository.GetClientes();
    
        // Act

        var clientes = await clientesTask;

        // Assert

        Assert.NotNull(clientes);
        Assert.IsType<List<ClienteModel>>(clientes);
        Assert.True(clientes.Any());
        Assert.Equal(newCliente.Nombre, clientes[0].Nombre);
        Assert.Equal(newCliente.Telefono, clientes[0].Telefono);
        Assert.Equal(newCliente.Email, clientes[0].Email);
    }

    [Fact]
    public async Task Get_ValidClienteId_ReturnCliente()
    {
        // Arrange
        var idCliente = 1;
            
        var clienteTask = clienteRepository.GetById(idCliente);

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
    public async Task Get_InvalidClienteId_ThrowsException()
    {
        // Arrange
        var invalidId = 10;
    
        // Act 
        async Task<Cliente> GetClienteTask()
        {
            return await clienteRepository.GetById(invalidId);
        }

        Func<Task> act = async () => await GetClienteTask();

        // Assert (Expect ClienteNotFoundException)
        Assert.NotNull(act);
        await Assert.ThrowsAsync<ClienteException>(act);
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

    [Fact]
    public async Task Save_NewCliente_ShouldSaveCliente()
    {
        // Arrange

        ResetDatabase();
        
        var newCliente = new Cliente()
        {
            IdCliente = -1,
            Nombre = "Pedro",
            Telefono = "809-999-9999",
            Email = "pedro@example.com"
        };
        
        // Act

        await clienteRepository.Save(newCliente);
        
        // Expect
        
        var clienteSaved = await clienteRepository.GetById(newCliente.IdCliente);

        // Assert

        Assert.NotNull(clienteSaved);
        Assert.IsType<Cliente>(clienteSaved);
        Assert.Equal(newCliente.Nombre, clienteSaved.Nombre);
        Assert.Equal(newCliente.Telefono, clienteSaved.Telefono);
        Assert.Equal(newCliente.Email, clienteSaved.Email);
    }

    [Fact]
    public async Task Update_ExistingCliente_ShouldUpdateCliente()
    {
        // Arrange
        
        var clienteToUpdate = await clienteRepository.GetById(1);
        clienteToUpdate.Nombre = "Naty";
        
        // Act 
        
        await clienteRepository.Update(clienteToUpdate);
        
        // Assert

        var clienteUpdated = await clienteRepository.GetById(1);

        Assert.NotNull(clienteUpdated);
        Assert.IsType<Cliente>(clienteUpdated);
        Assert.Equal(clienteToUpdate.Nombre, clienteUpdated.Nombre);
        Assert.Equal(clienteToUpdate.Telefono, clienteUpdated.Telefono);
        Assert.Equal(clienteToUpdate.Email, clienteUpdated.Email);
    }
}