using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;

public class PhotoneFlash : ObstacleBase
{
    private const int ObstacleDamage = 300;
    public PhotoneFlash()
        : base(ObstacleDamage)
    {
    }
}