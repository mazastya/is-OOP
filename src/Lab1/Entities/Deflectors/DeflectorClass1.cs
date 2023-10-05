namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class DeflectorClass1 : DeflectorBase
{
    private const int HitPointFromDeflector = 40;
    public DeflectorClass1()
        : base(HitPointFromDeflector)
    {
    }
}