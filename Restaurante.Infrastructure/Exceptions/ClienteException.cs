namespace Restaurante.Infrastructure.Exceptions;

public class ClienteException : Exception
{
    public ClienteException(string message) : base(message)
    {
        // X Logica para guadar el error.
    }
}