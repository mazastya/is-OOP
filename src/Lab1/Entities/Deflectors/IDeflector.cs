using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public interface IDeflector
{
    void TakeDamage(ObstacleBase obstacle);
}