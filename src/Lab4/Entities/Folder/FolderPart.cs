using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Folder;

public class FolderPart(string name) : IFolderPart
{
    private readonly List<IPartOfBlock> _partOfBlocks = new List<IPartOfBlock>();

    public string Name { get; set; } = name;

    public IEnumerable<IPartOfBlock> Subparts => _partOfBlocks;

    public void AddSubpartsFolder(IPartOfBlock partOfBlock)
    {
        _partOfBlocks.Add(partOfBlock);
    }

    public IPartOfBlock Clone()
    {
        return new FolderPart(Name);
    }
}