namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public abstract class PathSegment
{
    protected PathSegment(SpaseBase.SpaseBase spaseBase, int distanse)
    {
        Base = spaseBase;
        Distanse = distanse;
    }

    public int Distanse { get; }
    public SpaseBase.SpaseBase Base { get; }
}