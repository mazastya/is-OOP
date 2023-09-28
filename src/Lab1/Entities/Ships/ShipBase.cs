using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Microsoft.VisualBasic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class ShipBase
{
    protected ShipBase(IDeflector deflectorBase, EngineBase engineBase, JumpEngines jumpEngines, ArmourBase armourBase)
    {
        DeflectorBase = deflectorBase ?? throw new ArgumentNullException(nameof(deflectorBase));
        ArmourBase = armourBase;
        EngineBase = engineBase ?? throw new ArgumentNullException(nameof(engineBase));
        JumpEngines = jumpEngines ?? throw new ArgumentNullException(nameof(jumpEngines));
    }

    public IDeflector DeflectorBase { get; }

    // public PhotonDeflectors PhotonDeflectors { get; }
    public EngineBase EngineBase { get; }
    public JumpEngines JumpEngines { get; }
    public ArmourBase ArmourBase { get; }

    public void GetAttack(Collection obstacles)
    {
        foreach (ObstacleBase obstacle in obstacles)
        {
            DeflectorBase.TakeDamage(obstacle);
            ArmourBase.TakeDamage(obstacle);
        }
    }
}

/*
 * var engine1 = new Engine1()
 * var ship = new Ship(engine1)
 */