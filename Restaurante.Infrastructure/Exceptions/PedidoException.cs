namespace Restaurante.Infrastructure.Exceptions;

public class PedidoException : Exception
{
    public PedidoException(string message) : base(message)
    {
        // x logica para guadar el error.
    }
}