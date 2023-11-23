using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

public interface ITree
{
    public void BuildTree(IContext context, int maxDepth);
}