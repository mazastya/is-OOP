using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;

public class Meteorite : ObstacleBase
{
    private const int ObstacleDamage = 100;
    public Meteorite()
        : base(ObstacleDamage)
    {
    }
}