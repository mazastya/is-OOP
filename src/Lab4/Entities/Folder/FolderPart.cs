using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Folder;

public class FolderPart : IFolderPart
{
    public FolderPart(string name)
    {
        Name = name;
    }

    public IList<IPartOfBlock> PartOfBlocks { get; } = new List<IPartOfBlock>();
    public string Name { get; set; }

    public IEnumerable<IPartOfBlock> Subparts => PartOfBlocks;

    public void AddSubpartsFolder(IPartOfBlock partOfBlock)
    {
        PartOfBlocks.Add(partOfBlock);
    }

    public IPartOfBlock Clone()
    {
        return new FolderPart(Name);
    }
}