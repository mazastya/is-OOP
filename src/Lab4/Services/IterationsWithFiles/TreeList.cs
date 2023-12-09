using System;
using System.ComponentModel;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class TreeList : ICommand
{
    private readonly string _pathFile;
    private readonly int _maxDepth;

    public TreeList(string pathFile, int maxDepth)
    {
        _pathFile = pathFile;
        _maxDepth = maxDepth;
    }

    public FileResult Execute(IContext context)
    {
        ArgumentException.ThrowIfNullOrEmpty(_pathFile);

        IPartOfBlock treeBuild = context.TreeTraversal.BuildTree(context, _maxDepth);
        string stringBuildTree = context.StringBuildForTreeForTree.GetStringToBuildTree(treeBuild);
        new ConsoleOutput().Output(stringBuildTree);
        return new FileResult(FileResultType.Success);
    }
}