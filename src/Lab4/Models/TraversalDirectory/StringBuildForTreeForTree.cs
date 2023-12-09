using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Folder;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

public class StringBuildForTreeForTree : IStringBuildForTree
{
    private readonly char _pathSymbol;
    private readonly char _folderSymbol;
    private readonly char _fileSymbol;
    private readonly int _tabulation;

    public StringBuildForTreeForTree(
        char pathSymbol = '-',
        char folderSymbol = '|',
        char fileSymbol = '>',
        int tabulation = 4)
    {
        _pathSymbol = pathSymbol;
        _folderSymbol = folderSymbol;
        _fileSymbol = fileSymbol;
        _tabulation = tabulation;
    }

    public string GetStringToBuildTree(IPartOfBlock partOfTree)
    {
        string output = string.Empty;
        return BuildTreeString(ref output, partOfTree, 0);
    }

    private string BuildTreeString(ref string output, IPartOfBlock partOfBlock, int maxDepth)
    {
        ArgumentException.ThrowIfNullOrEmpty(output);
        ArgumentNullException.ThrowIfNull(partOfBlock);

        if (partOfBlock is not IFolderPart folderPart)
        {
            return output;
        }

        output += new string(_pathSymbol, maxDepth + _tabulation) +
                  (partOfBlock is IFolderPart ? _folderSymbol : _fileSymbol) +
                  partOfBlock.Name +
                  Environment.NewLine;

        foreach (IPartOfBlock subpart in folderPart.Subparts)
        {
            BuildTreeString(ref output, subpart, maxDepth + 1);
        }

        return output;
    }
}