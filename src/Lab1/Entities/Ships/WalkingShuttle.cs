using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class WalkingShuttle : ShipBase
{
    private readonly EngineBase _engineBase;
    private readonly ArmourBase _armourBase;
    private readonly AntiNeutronEmitter? _antiNeutronEmitter;
    private readonly int _weightCharacteristic;

    public WalkingShuttle(IDeflector? deflectorBase, EngineBase engineBase, JumpEngines? jumpEngines, ArmourBase armourBase, AntiNeutronEmitter? antiNeutronEmitter, int weightCharacteristic)
        : base(
            deflectorBase,
            engineBase: new ImpulseEngineClassC(),
            jumpEngines,
            armourBase: new ArmourClass1(),
            antiNeutronEmitter: new AntiNeutronEmitter(),
            weightCharacteristic: 10)
    {
        _engineBase = engineBase;
        _armourBase = armourBase;
        _antiNeutronEmitter = antiNeutronEmitter;
        _weightCharacteristic = weightCharacteristic;
    }
}