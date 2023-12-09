using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

[SuppressMessage("Category", "CA1305", Justification = "Parsing")]
public class TreeListFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "tree" && request[1] == "list" && request[2] == "-d";
    }

    protected override ICommand Handle(string[] request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new TreeList(
            request[2],
            maxDepth: int.Parse(request[4]));
    }
}