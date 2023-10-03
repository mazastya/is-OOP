using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaseBase;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class JumpEngines : EngineBase
{
    private const double _fuelConsumedPerHour = 50;

    public JumpEngines(TypesOfJumpEngines typeOfJumpEngines, int maximumLengthOfJump)
    {
        TypeOfJumpEngines = typeOfJumpEngines;
        MaximumLengthOfJump = maximumLengthOfJump;
    }

    public TypesOfJumpEngines TypeOfJumpEngines { get; }
    public double ShipSpeed { get; } = 100;
    public int MaximumLengthOfJump { get; }

    public override JumpEngines? IsEngineSuitableForTheEnvironment(PathSegment pathSegment)
    {
        return (pathSegment.Base is HighDensitySpaceNebulae) ? this : null;
    }

    public override double HowMuchFuelIsSpentOnTheJourney(double pathLenght, int weightCharacteristic)
    {
        switch (TypeOfJumpEngines)
        {
            case TypesOfJumpEngines.AlphaJumpEngine:
            {
                return (GetTimeToTravel(pathLenght, weightCharacteristic) * _fuelConsumedPerHour) * weightCharacteristic;
            }

            case TypesOfJumpEngines.GammaJumpEngine:
            {
                return (GetTimeToTravel(pathLenght, weightCharacteristic) * _fuelConsumedPerHour * _fuelConsumedPerHour) * weightCharacteristic;
            }

            case TypesOfJumpEngines.OmegaJumpEngine:
            {
                return (GetTimeToTravel(pathLenght, weightCharacteristic) * _fuelConsumedPerHour * Math.Log(_fuelConsumedPerHour)) * weightCharacteristic;
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