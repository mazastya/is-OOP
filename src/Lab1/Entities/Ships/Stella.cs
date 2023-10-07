using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Stella : ShipBase
{
    public Stella()
        : base(
            new DeflectorClass1(),
            new ImpulseEngineClassC(),
            new JumpEngines(TypesOfJumpEngines.OmegaJumpEngine, 500),
            new ArmourClass1(),
            new AntiNeutronEmitter(),
            10)
    {
    }
}