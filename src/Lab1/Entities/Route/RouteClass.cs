using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;

public class RouteClass
{
    private IList<PathSegment> _pathSegments;

    public RouteClass(IList<PathSegment> pathSegments)
    {
        _pathSegments = pathSegments;
    }
}