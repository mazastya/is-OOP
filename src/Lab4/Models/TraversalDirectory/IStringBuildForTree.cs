using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

public interface IStringBuildForTree
{
    public string GetStringToBuildTree(IPartOfBlock partOfTree);
}