using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class WalkingShuttle : ShipBase
{
    private readonly EngineBase _engineBase;
    private readonly ArmourBase _armourBase;

    public WalkingShuttle(IDeflector deflectorBase, EngineBase engineBase, JumpEngines jumpEngines, ArmourBase armourBase)
        : base(
            deflectorBase,
            engineBase: new ImpulseEngineClassC(),
            jumpEngines,
            armourBase: new ArmourClass1())
    {
        _engineBase = engineBase;
        _armourBase = armourBase;
    }
}