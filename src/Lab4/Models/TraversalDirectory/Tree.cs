using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

public class Tree : ITree
{
    public Tree(string path)
    {
        Path = path;
    }

    public string Path { get; set; }
    public void BuildTree(string path, int maxDepth)
    {
        TraverseTree(new DirectoryInfo(path), string.Empty, maxDepth);
    }

    private static void OutputFiles(FileInfo[] files, string tabulation)
    {
        Console.OutputEncoding = Encoding.UTF8;
        foreach (FileInfo file in files)
        {
            Console.WriteLine(tabulation + "\u2751" + file.Name);
        }
    }

    private void TraverseTree(DirectoryInfo directoryInfo, string line, int? maxDepth = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(line);
        Console.OutputEncoding = Encoding.UTF8;

        if (maxDepth is not null && maxDepth == 0) return;

        Console.WriteLine(line + "\ud83d\uddc1" + directoryInfo.Name);
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
            Console.WriteLine(line + "|   ");
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