using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class RenameFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "file" && request[1] == "rename";
    }

    protected override void Handle(string[] request)
    {
        var renameFile = new RenameFile(request[2], request[3]);
        renameFile.Execute(request[2]);
    }
}