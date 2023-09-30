using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaseBase;

public class OrdinarySpace : SpaseBase
{
    public OrdinarySpace(ICollection<ObstacleBase> obstacle)
        : base(obstacle)
    {
        if (obstacle.Any(obstacle => obstacle is not (Meteorite or Asteroid)))
        {
            throw new ArgumentException("an obstacle is entered incorrectly", nameof(obstacle));
        }
    }
}