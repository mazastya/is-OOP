using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class ShipObstacleCollision
{
    public static Stat ShipObstacleCollisionMethod(ShipBase shipBase, RouteClass routeClass)
    {
        ArgumentNullException.ThrowIfNull(nameof(shipBase));
        ArgumentNullException.ThrowIfNull(nameof(routeClass));

        var stat = new Stat();
        foreach (PathSegment segment in routeClass.PathSegments)
        {
            EngineBase? baseEngine = shipBase.EngineBase?.IsEngineSuitableForTheEnvironment(segment);
            JumpEngines? jump = shipBase.JumpEngines?.IsEngineSuitableForTheEnvironment(segment);

            EngineBase resultEngine;

            if (baseEngine is null)
            {
                if (jump is null)
                {
                    stat.Status = ResultOfDamage.SpaceShipIsDestroyed;
                    return stat;
                }

                if (jump.MaximumLengthOfJump < segment.Distance)
                {
                    stat.Status = ResultOfDamage.SpaceShipIsLostBadJump;
                    return stat;
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

            // EngineBase? resultEngine = jump ?? baseEngine;
            switch (resultOfDamage)
            {
                case ResultOfDamage.CrewDied:
                    stat.CrewIsAlive = false;
                    return stat;
                case ResultOfDamage.SpaceShipIsDestroyed:
                    stat.Status = resultOfDamage;
                    return stat;
                case ResultOfDamage.Success:
                    stat.FuelConsumedToJourney +=
                        resultEngine.HowMuchFuelIsSpentOnTheJourney(segment.Distance, shipBase.WeightCharacteristic);
                    break;
            }
        }

        return stat;
    }
}