namespace Kolokwium2.Exception;

public class BadRequestException : System.Exception
{
    public BadRequestException(string? message) : base(message)
    {
    }
}