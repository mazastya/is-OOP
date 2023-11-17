using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class MoveFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "file" && request[1] == "move";
    }

    protected override void Handle(string[] request)
    {
        var moveFile = new MoveFile(request[2], request[3]);
        moveFile.Execute(request[2]);
    }
}