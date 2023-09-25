using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineClassE : ImpulseEngineBase
{
    private readonly double _speed = 30;

    public override double GetTimeToTravel(double pathLength)
    {
        return pathLength / _speed;
    }

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght)
    {
        double fuelConsumedPerHour = GetGettingAcceleration(pathLenght) * pathLenght;

        // double fuelConsumedPerHour = Math.Log(1 + (pathLenght * Math.Log(GetGettingAcceleration(pathLenght), Math.E)));
        return FuelToGetStarted + (fuelConsumedPerHour * pathLenght);
    }

    private double GetGettingAcceleration(double pathLength)
    {
        return Math.E * Math.Pow(GetTimeToTravel(pathLength), 2) / 6;
    }
}