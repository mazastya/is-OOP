namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineClassC : ImpulseEngineBase
{
    private const double FuelConsumedPerHour = 10;

    public override double GetTimeToTravel(double pathLength, int weightCharacteristic)
    {
        return (FuelConsumedPerHour * pathLength) * weightCharacteristic;
    }

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght, int weightCharacteristic)
    {
        return (FuelToGetStarted + (FuelConsumedPerHour * pathLenght)) * weightCharacteristic;
    }
}