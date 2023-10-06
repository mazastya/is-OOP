using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class PathSegment
{
    public PathSegment(SpaceEnvironments.SpaseBase spaseBase, int distance)
    {
        ArgumentNullException.ThrowIfNull(nameof(spaseBase));
        ArgumentNullException.ThrowIfNull(nameof(distance));
        if (distance < 0)
        {
            throw new ArgumentException("Negative value is not possible", nameof(distance));
        }

        Base = spaseBase;
        Distance = distance;
    }

    public int Distance { get; }
    public SpaceEnvironments.SpaseBase Base { get; }
}