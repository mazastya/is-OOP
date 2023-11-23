using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class ConnectFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "connect" && request[2] == "-m";
    }

    protected override ICommand Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new Connect(
            pathFile: request[1],
            mode: request[3]);
    }
}