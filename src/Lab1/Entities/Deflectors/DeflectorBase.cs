using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class DeflectorBase : IDeflector
{
    private double _currentHitPointDeflector;
    protected DeflectorBase(int hitPointFromDeflector)
    {
        ArgumentNullException.ThrowIfNull(nameof(hitPointFromDeflector));
        _currentHitPointDeflector = hitPointFromDeflector;
    }

    public ResultOfDamage TakeDamage(ObstacleBase obstacle)
    {
        ArgumentNullException.ThrowIfNull(nameof(obstacle));

        if (obstacle is PhotoneFlash)
            return ResultOfDamage.CrewIsDead;

        double damage = _currentHitPointDeflector >= obstacle.Damage
            ? obstacle.Damage
            : _currentHitPointDeflector;

        _currentHitPointDeflector -= damage;
        obstacle.TakeDamage(damage);
        return ResultOfDamage.Success;
    }
}