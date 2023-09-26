namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;

public abstract class ArmourBase
{
    protected DeflectorBase(bool status)
    {
        Status = status;
    }

    protected double HitPointDeflector { get; set; }

    protected bool Status { get; set; }

    protected void TakeDamage(ObstacleTypes obstacleType)
    {
        HitPointDeflector -= (int)obstacleType;
    }
}