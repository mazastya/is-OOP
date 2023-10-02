using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Stella : ShipBase
{
    private readonly IDeflector _deflectorBase;
    private readonly EngineBase _engineBase;
    private readonly JumpEngines _jumpEngines;
    private readonly ArmourBase _armourBase;
    private readonly int _weightCharacteristic;

    public Stella(IDeflector deflectorBase, EngineBase engineBase, JumpEngines jumpEngines, ArmourBase armourBase, int weightCharacteristic)
        : base(
            deflectorBase: new DeflectorClass1(),
            engineBase: new ImpulseEngineClassC(),
            jumpEngines: new JumpEngines(TypesOfJumpEngines.OmegaJumpEngine),
            armourBase: new ArmourClass1(),
            weightCharacteristic: 10)
    {
        _deflectorBase = deflectorBase;
        _engineBase = engineBase;
        _jumpEngines = jumpEngines;
        _armourBase = armourBase;
        _weightCharacteristic = weightCharacteristic;
    }
}