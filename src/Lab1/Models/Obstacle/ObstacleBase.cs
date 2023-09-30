using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public abstract class ObstacleBase
{
    protected ObstacleBase(double damageFromObstacle)
    {
        Damage = damageFromObstacle;
    }

    public double Damage { get; private set; }

    public void TakeDamage(double damage)
    {
        Damage -= damage;
    }
}