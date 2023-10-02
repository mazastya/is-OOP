using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngines : EngineBase
{
    private const double FuelConsumedPerHour = 50;

    public JumpEngines(TypesOfJumpEngines typeOfJumpEngines)
    {
        TypeOfJumpEngines = typeOfJumpEngines;
    }

    private TypesOfJumpEngines TypeOfJumpEngines { get; }
    private double ShipSpeed { get; } = 100;

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght, int weightCharacteristic)
    {
        switch (TypeOfJumpEngines)
        {
            case TypesOfJumpEngines.AlphaJumpEngine:
            {
                return (GetTimeToTravel(pathLenght, weightCharacteristic) * FuelConsumedPerHour) * weightCharacteristic;
            }

            case TypesOfJumpEngines.GammaJumpEngine:
            {
                return (GetTimeToTravel(pathLenght, weightCharacteristic) * FuelConsumedPerHour * FuelConsumedPerHour) * weightCharacteristic;
            }

            case TypesOfJumpEngines.OmegaJumpEngine:
            {
                return (GetTimeToTravel(pathLenght, weightCharacteristic) * FuelConsumedPerHour * Math.Log(FuelConsumedPerHour)) * weightCharacteristic;
            }

            default:
                return 100; // типа кода ошибки
        }
    }

    public override double GetTimeToTravel(double pathLength, int weightCharacteristic)
    {
        return (pathLength / ShipSpeed) * weightCharacteristic;
    }
}