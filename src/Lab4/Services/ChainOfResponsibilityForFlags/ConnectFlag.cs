using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class ConnectFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "connect" && request[2] == "-m";
    }

    protected override string Handle(string[] request)
    {
        var сonnect = new Сonnect(request[1], new FileSystem(), request[3]);
        сonnect.Execute(request[1]);
        return "connect complited";
    }
}