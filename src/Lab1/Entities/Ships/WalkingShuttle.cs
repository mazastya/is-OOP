using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class WalkingShuttle : ShipBase
{
    public WalkingShuttle()
        : base(
            null,
            new ImpulseEngineClassC(),
            null,
            new ArmourClass1(),
            new AntiNeutronEmitter(),
            10)
    {
    }
}