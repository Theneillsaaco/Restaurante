namespace Restaurante.Infrastructure.Exceptions;

public class DetallePedidoException : Exception
{
    public DetallePedidoException(string message) : base(message)
    {
        // x logica para guadar el error.
    }
}