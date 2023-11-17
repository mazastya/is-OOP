using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

[SuppressMessage("Category", "CA1305", Justification = "Parsing")]
public class TreeListFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        return request[0] == "tree" && request[1] == "list" && request[2] == "-d";
    }

    protected override string Handle(string[] request)
    {
        var tree = new Tree(request[2]);
        tree.BuildTree(request[2], int.Parse(request[4]));
        return "tree list complete";
    }
}