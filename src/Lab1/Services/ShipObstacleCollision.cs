using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public abstract class ShipObstacleCollision
{
    public static TotalStatistics ShipObstacleCollisionMethod(ShipBase shipBase, RouteClass routeClass)
    {
        ArgumentNullException.ThrowIfNull(nameof(shipBase));
        ArgumentNullException.ThrowIfNull(nameof(routeClass));

        var totalStatistics = new TotalStatistics();
        foreach (PathSegment segment in routeClass.PathSegments)
        {
            EngineBase? baseEngine = shipBase.EngineBase?.IsEngineSuitableForTheEnvironment(segment);
            JumpEngines? jump = shipBase.JumpEngines?.IsEngineSuitableForTheEnvironment(segment);

            EngineBase resultEngine;

            if (baseEngine is null)
            {
                if (jump is null)
                {
                    totalStatistics.Status = ResultOfDamage.SpaceShipIsDestroyed;
                    return totalStatistics;
                }

                if (jump.MaximumLengthOfJump < segment.Distance)
                {
                    totalStatistics.Status = ResultOfDamage.JumpEngineRangShortfall;
                    return totalStatistics;
                }

                resultEngine = jump;
            }
            else
            {
                resultEngine = baseEngine;
            }

            ResultOfDamage resultOfDamage = ResultOfDamage.Success;
            foreach (ObstacleBase obstacle in segment.Base.ObstacleBases)
            {
                resultOfDamage = shipBase.GetAttack(obstacle);
                if (resultOfDamage != ResultOfDamage.Success)
                    break;
            }

            switch (resultOfDamage)
            {
                case ResultOfDamage.CrewIsDead:
                    totalStatistics.CrewIsAlive = false;
                    return totalStatistics;
                case ResultOfDamage.SpaceShipIsDestroyed:
                    totalStatistics.Status = resultOfDamage;
                    return totalStatistics;
                case ResultOfDamage.Success:
                    totalStatistics.FuelConsumedToJourney +=
                        resultEngine.HowMuchFuelIsSpentOnTheJourney(segment.Distance, shipBase.WeightCharacteristic);
                    break;
            }
        }

        return totalStatistics;
    }
}