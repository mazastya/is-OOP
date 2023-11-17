using System;
using System.ComponentModel;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class TreeList : Command
{
    public TreeList(string pathFile, Tree tree, int maxDepth = 1)
        : base(pathFile)
    {
        Tree = tree;
        MaxDepth = maxDepth;
    }

    private int MaxDepth { get; }
    private Tree Tree { get; }

    public override void Execute(string pathFile)
    {
        ArgumentException.ThrowIfNullOrEmpty(pathFile);
        Tree.BuildTree(pathFile, MaxDepth);
    }
}