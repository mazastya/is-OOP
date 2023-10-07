using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;

public class CosmoWhale : ObstacleBase
{
    private const int ObstacleDamage = 1000;
    public CosmoWhale()
        : base(ObstacleDamage)
    {
    }
}