using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineClassE : ImpulseEngineBase
{
    private readonly double _speed = 30;

    public override double GetTimeToTravel(double pathLength, int weightCharacteristic)
    {
        return (pathLength / _speed) * weightCharacteristic;
    }

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght, int weightCharacteristic)
    {
        double fuelConsumedPerHour = GetGettingAcceleration(pathLenght, weightCharacteristic) * pathLenght;

        // double fuelConsumedPerHour = Math.Log(1 + (pathLenght * Math.Log(GetGettingAcceleration(pathLenght), Math.E)));
        return (FuelToGetStarted + (fuelConsumedPerHour * pathLenght)) * weightCharacteristic;
    }

    private double GetGettingAcceleration(double pathLength, int weightCharacteristic)
    {
        return (Math.E * Math.Pow(GetTimeToTravel(pathLength, weightCharacteristic), 2) / 6) * weightCharacteristic;
    }
}