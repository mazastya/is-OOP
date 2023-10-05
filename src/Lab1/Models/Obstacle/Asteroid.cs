using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : ObstacleBase
{
    private const int ObstacleDamage = 50;
    public Asteroid()
        : base(ObstacleDamage)
    {
    }
}