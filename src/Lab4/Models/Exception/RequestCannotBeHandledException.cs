namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Exception;

public class RequestCannotBeHandledException : System.Exception
{
    public RequestCannotBeHandledException(string message)
        : base(message)
    {
    }

    public RequestCannotBeHandledException()
    {
    }

    public RequestCannotBeHandledException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}