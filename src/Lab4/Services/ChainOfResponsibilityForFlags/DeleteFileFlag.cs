using System;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class DeleteFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "file" && request[1] == "delete";
    }

    protected override ICommand Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new DeleteFile(request[2]);
    }
}