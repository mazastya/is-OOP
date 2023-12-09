using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

public interface ITree
{
    public IPartOfBlock BuildTree(IContext context, int maxDepth);
}