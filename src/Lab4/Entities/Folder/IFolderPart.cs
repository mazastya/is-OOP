using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Folder;

public interface IFolderPart
{
    IEnumerable<IPartOfBlock> Subparts { get; set; }
    public void AddSubpartsFolder(IPartOfBlock partOfBlock);
}