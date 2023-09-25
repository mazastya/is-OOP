using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineClassE : ImpulseEngineBase
{
    private readonly double _acceleration = 2;

    public override double GetTimeToTravel(double pathLength)
    {
        double fuelConsumedPerHour = Math.Log(1 + (pathLength * Math.Log(_acceleration, Math.E)));
        return fuelConsumedPerHour * pathLength;
    }

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght)
    {
        double fuelConsumedPerHour = Math.Log(1 + (pathLenght * Math.Log(_acceleration, Math.E)));
        return FuelToGetStarted + (fuelConsumedPerHour * pathLenght);
    }
}