namespace Restaurante.Infrastructure.Exceptions;

public class MenuException : Exception
{
    public MenuException(string message) : base(message)
    { 
        // x logica para guadar el error.
    }
}