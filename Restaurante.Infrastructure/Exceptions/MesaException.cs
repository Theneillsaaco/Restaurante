namespace Restaurante.Infrastructure.Exceptions;

public class MesaException : Exception
{
    public MesaException(string message) : base(message)
    {
        // x logica para guadar el error.
    }
}