using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FilePart;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Folder;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

public class Tree(string path) : ITree
{
    public string Path1 { get; } = path;

    public IPartOfBlock BuildTree(IContext context, int maxDepth)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(maxDepth);

        IPartOfBlock partOfBlock = GetPartOfBlock(context.FileSystem, context.Path);

        if (maxDepth <= 0 || partOfBlock is not IFolderPart folderPart)
        {
            return partOfBlock;
        }

        IEnumerable<string> files;
        try
        {
            files = context.FileSystem.ListDirectory(context.Path, maxDepth);
        }
        catch (ArgumentException)
        {
            // files = ArraySegment<string>.Empty;
            files = Array.Empty<string>();
        }

        foreach (string pathFile in files)
        {
            IContext newContext = context.Clone();
            newContext.FileSystem.ChangeDirectory(pathFile);
            folderPart.AddSubpartsFolder(BuildTree(newContext, maxDepth - 1));
        }

        return partOfBlock;
    }

    private static IPartOfBlock GetPartOfBlock(IFileSystem fileSystem, string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(fileSystem);

        string partOfFileName = Path.GetFileName(Path.GetDirectoryName(path)) ?? path;

        return fileSystem.IsFolder(path)
            ? new FolderPart(partOfFileName)
            : new FilePart(partOfFileName);
    }
}