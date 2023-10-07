using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public abstract class ObstacleBase
{
    protected ObstacleBase(double damageFromObstacle)
    {
        ArgumentNullException.ThrowIfNull(nameof(damageFromObstacle));
        if (damageFromObstacle < 0)
        {
            throw new ArgumentException("Negative value is not possible", nameof(damageFromObstacle));
        }

        Damage = damageFromObstacle;
    }

    public double Damage { get; private set; }

    public void TakeDamage(double damage)
    {
        Damage -= damage;
    }
}