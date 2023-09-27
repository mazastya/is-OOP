using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Meredian : ShipBase
{
    public Meredian(IDeflector deflectorBase, EngineBase engineBase, ImpulseEngineBase impulseEngineBase, ArmourBase armourBase)
        : base(deflectorBase, engineBase, impulseEngineBase, armourBase)
    {
    }
}