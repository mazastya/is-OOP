namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;

public abstract class ArmourBase
{
    protected double HitPointArmour { get; set; }
    protected void TakeDamage(ObstacleTypeForArmour obstacleTypeForArmour)
    {
        HitPointArmour -= (int)obstacleTypeForArmour;
    }
}