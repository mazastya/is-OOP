namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class EngineBase
{
    public abstract double GetTimeToTravel(double pathLength, int weightCharacteristic);  // сколько времени в космосе (для вынесения вердикта)

    public abstract double HowMuchFuelIsSpentOnTheJourney(double pathLenght, int weightCharacteristic);  // сколько топлива потратили

    // protected IsEngineSuitableForTheEnvironment(EngineBase engineBase, SpaseBase.SpaseBase spaseBase)
    // {
    //     if (engineBase is ImpulseEngineClassC and spaseBase is )
    // }
}