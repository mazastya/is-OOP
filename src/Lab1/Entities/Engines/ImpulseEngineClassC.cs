namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ImpulseEngineClassC : ImpulseEngineBase
{
    private const double FuelConsumedPerHour = 5;

    public override double GetTimeToTravel(double pathLength)
    {
        return FuelConsumedPerHour * pathLength;
    }

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght)
    {
        return FuelToGetStarted + (FuelConsumedPerHour * pathLenght);
    }
}