using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaseBase;

public class SpaseBase
{
    private ICollection<ObstacleBase> _obstacle;

    public SpaseBase(ICollection<ObstacleBase> obstacle)
    {
        _obstacle = obstacle;
    }
    }