using System;
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
        ArgumentNullException.ThrowIfNull(nameof(pathSegment));
        return pathSegment.Base is HighDensitySpaceNebulae ? null : this;
    }
}