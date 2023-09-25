namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class EngineBase
{
    public abstract double GetTimeToTravel(double pathLength);  // сколько времени в космосе (для вынесения вердикта)

    public abstract double HowMuchFuelIsSpentOnTheJourney(double pathLenght);  // сколько топлива потратили
}