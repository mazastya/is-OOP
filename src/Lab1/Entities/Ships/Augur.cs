using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Augur : ShipBase
{
    public Augur()
        : base(
            new DeflectorClass3(),
            new ImpulseEngineClassE(),
            new JumpEngines(TypesOfJumpEngines.AlphaJumpEngine, 100),
            new ArmourClass3(),
            new AntiNeutronEmitter(),
            50)
    {
    }
}