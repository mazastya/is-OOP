using System.Windows.Input;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public interface IHandler
{
    void SetNextHandler(IHandler handler);
    public string HandleRequest(string[] request);
}