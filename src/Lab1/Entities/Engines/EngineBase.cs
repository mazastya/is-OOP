using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaseBase;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class EngineBase
{
    public abstract double GetTimeToTravel(double pathLength, int weightCharacteristic);  // сколько времени в космосе (для вынесения вердикта)

    public abstract double HowMuchFuelIsSpentOnTheJourney(double pathLenght, int weightCharacteristic);  // сколько топлива потратили

    public virtual EngineBase? IsEngineSuitableForTheEnvironment(PathSegment pathSegment)
    {
        return pathSegment.Base is HighDensitySpaceNebulae ? null : this;
    }

    // public Result IsPossibleToTravel(double wayLength, PathSegment pathSegment)
    // {
    //     if (pathSegment.Base is not NitrinoParticleNebulae)
    //         return Result.SpaceShipLostUnsuitableBiome;
    //     return wayLength <= MaximumLengthOfJump ? ResultOfFly.Success : ResultOfFly.SpaseShipLostBadJump;
    // }
}