using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class MoveFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "file" && request[1] == "move";
    }

    protected override ICommand Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new MoveFile(
            pathFile: request[2],
            newPathFile: request[3]);
    }
}