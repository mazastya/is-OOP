using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class CopyFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "file" && request[1] == "copy";
    }

    protected override ICommand Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new CopyFile(request[2], request[3]);
    }
}