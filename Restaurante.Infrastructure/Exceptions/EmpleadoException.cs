namespace Restaurante.Infrastructure.Exceptions;

public class EmpleadoException : Exception
{
    public EmpleadoException(string message) : base(message)
    {
        // x logica para guardar el error.
    }
}