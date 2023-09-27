using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;

public abstract class ArmourBase
{
    private double _currentHitPointDeflector;

    protected ArmourBase(int num)
    {
        _currentHitPointDeflector = num;
    }

    public bool IsDeadInside => _currentHitPointDeflector <= 0;

    public void TakeDamage(ObstacleBase obstacle)
    {
        _currentHitPointDeflector -= obstacle.Damage;
    }
}