using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class ShowFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        if (request[0] == "file" && request[1] == "show")
        {
            if (request[3] == "-m" && request[4] == "console")
            {
                return true;
            }
        }
        else
        {
            return false;
        }

        return false;
    }

    protected override ICommand Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new ShowFile(request[2], request[4]);
    }
}