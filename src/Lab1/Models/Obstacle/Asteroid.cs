using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

public class Asteroid : ObstacleBase
{
    // public Asteroid(int damage)
    // {
    //     Damage = damage;
    // }
    public Asteroid()
        : base(50)
    {
    }
}