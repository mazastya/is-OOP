namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public interface ILogger<in T>
{
    public void Log(T messageLog);
}