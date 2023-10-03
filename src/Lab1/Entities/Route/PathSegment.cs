using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class PathSegment
{
    public PathSegment(SpaceEnvironments.SpaseBase spaseBase, int distance)
    {
        Base = spaseBase;
        Distance = distance;
    }

    public int Distance { get; }
    public SpaceEnvironments.SpaseBase Base { get; }
}