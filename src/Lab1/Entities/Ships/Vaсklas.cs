using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Vaсklas : ShipBase
{
    private readonly IDeflector _deflectorBase;
    private readonly EngineBase _engineBase;
    private readonly JumpEngines _jumpEngines;
    private readonly ArmourBase _armourBase;
    private readonly AntiNeutronEmitter? _antiNeutronEmitter;
    private readonly int _weightCharacteristic;

    public Vaсklas(IDeflector deflectorBase, EngineBase engineBase, JumpEngines jumpEngines, ArmourBase armourBase, AntiNeutronEmitter? antiNeutronEmitter, int weightCharacteristic)
        : base(
            deflectorBase: new DeflectorClass1(),
            engineBase: new ImpulseEngineClassE(),
            jumpEngines: new JumpEngines(TypesOfJumpEngines.GammaJumpEngine, 200),
            armourBase: new ArmourClass2(),
            antiNeutronEmitter: new AntiNeutronEmitter(),
            weightCharacteristic: 20)
    {
        _deflectorBase = deflectorBase;
        _engineBase = engineBase;
        _jumpEngines = jumpEngines;
        _armourBase = armourBase;
        _antiNeutronEmitter = antiNeutronEmitter;
        _weightCharacteristic = weightCharacteristic;
    }
}