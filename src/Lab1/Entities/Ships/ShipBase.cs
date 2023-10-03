using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Microsoft.VisualBasic;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class ShipBase
{
    protected ShipBase(IDeflector? deflectorBase, EngineBase? engineBase, JumpEngines? jumpEngines, ArmourBase armourBase, AntiNeutronEmitter? antiNeutronEmitter, int weightCharacteristic)
    {
        WeightCharacteristic = weightCharacteristic;
        DeflectorBase = deflectorBase;
        ArmourBase = armourBase;
        AntiNeutronEmitter = antiNeutronEmitter;

        // if (engineBase is null and jumpEngines is null)
        EngineBase = engineBase;
        JumpEngines = jumpEngines;
    }

    public int WeightCharacteristic { get; }

    public IDeflector? DeflectorBase { get; }

    // public PhotonDeflectors PhotonDeflectors { get; }
    public EngineBase? EngineBase { get; }
    public JumpEngines? JumpEngines { get; }
    public ArmourBase ArmourBase { get; }
    public AntiNeutronEmitter? AntiNeutronEmitter { get; }

    public ResultOfDamage GetAttack(ObstacleBase obstacle)
    {
        if (obstacle is CosmoWhale && AntiNeutronEmitter is null)
        {
            return ResultOfDamage.SpaceShipIsDestroyed;
        }

        ResultOfDamage firstStep = DeflectorBase?.TakeDamage(obstacle) ?? ResultOfDamage.Success;
        return firstStep != ResultOfDamage.CrewDied ? ArmourBase.TakeDamage(obstacle) : firstStep;
    }
}

/*
 * var engine1 = new Engine1()
 * var ship = new Ship(engine1)
 */