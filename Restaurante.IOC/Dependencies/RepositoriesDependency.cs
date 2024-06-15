using Microsoft.Extensions.DependencyInjection;
using Restaurante.Domain.Interfaces;
using Restaurante.Infrastructure.Repository;

namespace Restaurante.IOC.Dependencies;

public static class RepositoriesDependency
{
    public static void AddRepositoriesDependency(this IServiceCollection service)
    {
        // Repository services
        
        service.AddScoped<IClienteRepository, ClienteRepository>();
        service.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
        service.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        service.AddScoped<IFacturaRepository, FacturaRepository>();
        service.AddScoped<IMenuRepository, MenuRepository>();
        service.AddScoped<IMesaRepository, MesaRepository>();
        service.AddScoped<IPedidoRepository, PedidoRepository>();
        
        // Services...
    }
}