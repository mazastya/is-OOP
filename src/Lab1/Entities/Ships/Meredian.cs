using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Meredian : ShipBase
{
    public Meredian()
        : base(
            new PhotonDeflectors(new DeflectorClass2()),
            new ImpulseEngineClassE(),
            null,
            new ArmourClass2(),
            new AntiNeutronEmitter(),
            20)
    {
    }
}