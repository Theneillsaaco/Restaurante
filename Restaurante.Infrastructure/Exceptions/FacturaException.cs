namespace Restaurante.Infrastructure.Exceptions;

public class FacturaException : Exception
{
    public FacturaException(string message) : base(message)
    {
        // x logica para guadar el error.
    }
}