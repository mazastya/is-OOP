using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

public class Tree(string path) : ITree
{
    public string Path { get; set; } = path;

    public void BuildTree(IContext context, int maxDepth)
    {
        TraverseTree(new DirectoryInfo(path), string.Empty, maxDepth);
    }

    private static void OutputFiles(IEnumerable<FileInfo> files, string tabulation)
    {
        var consoleOutput = new ConsoleOutput();
        foreach (FileInfo file in files)
        {
            consoleOutput.Output(tabulation + "\u2751" + file.Name);
        }
    }

    private void TraverseTree(DirectoryInfo directoryInfo, string line, int? maxDepth = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(line);

        if (maxDepth is not null && maxDepth == 0) return;

        var consoleOutput = new ConsoleOutput();
        consoleOutput.Output(line + "\ud83d\uddc1" + directoryInfo.Name);
        if (line.Length >= 4 && line.Substring(line.Length - 4) == "\u2514" + "--")
        {
            line = line.Remove(line.Length - 4);
            line += "    ";
        }

        if (line.Length >= 4 && line.Substring(line.Length - 4) == "|--")
        {
            line = line.Remove(line.Length - 4);
            line += "|   ";
        }

        DirectoryInfo[] childrenDirectories = directoryInfo.GetDirectories();
        FileInfo[] childrenFiles = directoryInfo.GetFiles();

        if (childrenDirectories.Length != 0)
        {
            OutputFiles(childrenFiles, line + "|   ");
            consoleOutput.Output(line + "|   ");
        }
        else
        {
            OutputFiles(childrenFiles, line + "    ");
        }

        if (childrenDirectories.Length <= 0) return;
        foreach (DirectoryInfo childInfo in childrenDirectories)
        {
            if (childInfo == childrenDirectories.Last())
            {
                TraverseTree(childInfo, line + "\u2514" + "--", maxDepth is null ? null : maxDepth - 1);
            }
            else
            {
                TraverseTree(childInfo, line + "|--", maxDepth is null ? null : maxDepth - 1);
            }
        }
    }
}