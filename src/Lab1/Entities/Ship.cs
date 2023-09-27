using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Microsoft.VisualBasic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Ship
{
    private IDeflector _deflectorBase;
    private EngineBase _engineBase;
    private ImpulseEngineBase _impulseEngineBase;
    private ArmourBase _armourBase;

    protected Ship(IDeflector deflectorBase, EngineBase engineBase, ImpulseEngineBase impulseEngineBase, ArmourBase armourBase)
    {
        _deflectorBase = deflectorBase;
        _armourBase = armourBase ?? throw new ArgumentNullException(nameof(armourBase));
        _engineBase = engineBase;
        _impulseEngineBase = impulseEngineBase;
    }

    public void GetAttack(Collection obstacles)
    {
        foreach (ObstacleBase obstacle in obstacles)
        {
            _deflectorBase.TakeDamage(obstacle);
            _armourBase.TakeDamage(obstacle);
        }
    }
}

/*
 * var engine1 = new Engine1()
 * var ship = new Ship(engine1)
 */