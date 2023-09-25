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

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght)
    {
        switch (TypeOfJumpEngines)
        {
            case TypesOfJumpEngines.AlphaJumpEngine:
            {
                return GetTimeToTravel(pathLenght) * FuelConsumedPerHour;
            }

            case TypesOfJumpEngines.GammaJumpEngine:
            {
                return GetTimeToTravel(pathLenght) * FuelConsumedPerHour * FuelConsumedPerHour;
            }

            case TypesOfJumpEngines.OmegaJumpEngine:
            {
                return GetTimeToTravel(pathLenght) * FuelConsumedPerHour * Math.Log(FuelConsumedPerHour);
            }

            default:
                return 100; // типа кода ошибки
        }
    }

    public override double GetTimeToTravel(double pathLength)
    {
        return pathLength / ShipSpeed;
    }
}