using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;

public abstract class SpaseBase
{
    private IList<ObstacleBase> _obstacle;

    protected SpaseBase(ICollection<ObstacleBase> obstacle)
    {
        _obstacle = obstacle.ToList();
    }

    public IReadOnlyCollection<ObstacleBase> ObstacleBases => _obstacle.AsReadOnly();
}