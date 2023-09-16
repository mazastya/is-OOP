namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public class NullDeflector : DeflectorBase
{
    public override ObstacleBase TakeDamage(ObstacleBase obstacle)
    {
        return obstacle;
    }
}