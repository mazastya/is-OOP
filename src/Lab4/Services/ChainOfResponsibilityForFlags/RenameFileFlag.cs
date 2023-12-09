using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class RenameFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "file" && request[1] == "rename";
    }

    protected override ICommand Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new RenameFile(
            pathFile: request[2],
            newNameFile: request[3]);
    }
}