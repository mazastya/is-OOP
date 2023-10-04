using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Vaсklas : ShipBase
{
    public Vaсklas(IDeflector deflectorBase)
        : base(
            deflectorBase: deflectorBase,
            new ImpulseEngineClassE(),
            new JumpEngines(TypesOfJumpEngines.GammaJumpEngine, 200),
            new ArmourClass2(),
            new AntiNeutronEmitter(),
            20)
    {
    }
}