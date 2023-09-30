using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaseBase;

public class NitrinoParticleNebulae : SpaseBase
{
    public NitrinoParticleNebulae(ICollection<ObstacleBase> obstacle)
        : base(obstacle)
    {
        if (obstacle.Any(obstacle => obstacle is not CosmoWhale))
        {
            throw new ArgumentException("an obstacle is entered incorrectly", nameof(obstacle));
        }
    }
}