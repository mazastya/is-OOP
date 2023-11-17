namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public interface IHandler
{
    void SetNextHandler(IHandler? handler);
    public void HandleRequest(string[] request);
}