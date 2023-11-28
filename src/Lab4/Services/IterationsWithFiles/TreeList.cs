using System;
using System.ComponentModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class TreeList(string pathFile, int maxDepth) : ICommand
{
    public FileResult Execute(IContext context)
    {
        ArgumentException.ThrowIfNullOrEmpty(pathFile);

        IPartOfBlock treeBuild = context.TreeTraversal.BuildTree(context, maxDepth);
        string stringBuildTree = context.StringBuildForTreeForTree.GetStringToBuildTree(treeBuild);
        new ConsoleOutput().Output(stringBuildTree);
        return new FileResult(FileResultType.Success);
    }
}