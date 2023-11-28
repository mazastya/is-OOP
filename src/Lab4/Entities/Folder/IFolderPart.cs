using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Folder;

public interface IFolderPart : IPartOfBlock
{
    IEnumerable<IPartOfBlock> Subparts { get; }
    public void AddSubpartsFolder(IPartOfBlock partOfBlock);
}