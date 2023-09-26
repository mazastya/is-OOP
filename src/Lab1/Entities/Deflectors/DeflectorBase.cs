namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public abstract class DeflectorBase
{
    protected double HitPointDeflector { get; set; }
    protected void TakeDamage(ObstacleTypes obstacleType)
    {
        HitPointDeflector -= (int)obstacleType;
    }
}