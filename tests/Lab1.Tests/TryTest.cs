using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Armour;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Route;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaseBase;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Microsoft.VisualBasic;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TryTest
{
    public static IEnumerable<object[]> DataForTest1 =>
        new List<object[]>
        {
            new object[]
            {
                new WalkingShuttle(
                    null,
                    engineBase: new ImpulseEngineClassC(),
                    null,
                    armourBase: new ArmourClass1(),
                    antiNeutronEmitter: new AntiNeutronEmitter(),
                    weightCharacteristic: 10),
                ResultOfDamage.SpaceShipIsDestroyed,
            },
            new object[]
            {
                new Augur(
                    deflectorBase: new DeflectorClass3(),
                    engineBase: new ImpulseEngineClassE(),
                    jumpEngines: new JumpEngines(TypesOfJumpEngines.AlphaJumpEngine, 100),
                    armourBase: new ArmourClass3(),
                    antiNeutronEmitter: new AntiNeutronEmitter(),
                    weightCharacteristic: 50),
                ResultOfDamage.JumpEngineRangShortfall,
            },
        };

    public static IEnumerable<object[]> DataForTest2 =>
        new List<object[]>
        {
            new object[]
            {
                new Vaсklas(
                    deflectorBase: new DeflectorClass1(),
                    engineBase: new ImpulseEngineClassE(),
                    jumpEngines: new JumpEngines(TypesOfJumpEngines.GammaJumpEngine, 200),
                    armourBase: new ArmourClass2(),
                    antiNeutronEmitter: new AntiNeutronEmitter(),
                    weightCharacteristic: 20),
                false,
            },

            // new object[]
            // {
            //     new Vaсklas(
            //         deflectorBase: new PhotonDeflectors(new DeflectorClass1()),
            //         engineBase: new ImpulseEngineClassE(),
            //         jumpEngines: new JumpEngines(TypesOfJumpEngines.GammaJumpEngine, 200),
            //         armourBase: new ArmourClass2(),
            //         antiNeutronEmitter: new AntiNeutronEmitter(),
            //         weightCharacteristic: 20),
            //     true,
            // },
        };

    [Theory]
    [MemberData(nameof(DataForTest1))]
    public void TestTryOne(ShipBase shipBase, ResultOfDamage expectedResult)
    {
        var obstacles = new List<ObstacleBase>();
        var environment = new HighDensitySpaceNebulae(obstacles);
        var pathSegment = new PathSegment(environment, 101);
        var route = new RouteClass(new List<PathSegment> { pathSegment });

        TotalStatistics totalStatistics = ShipObstacleCollision.ShipObstacleCollisionMethod(shipBase, route);
        Assert.Equal(expectedResult, totalStatistics.Status);
    }

    [Theory]
    [MemberData(nameof(DataForTest2))]
    public void Test2(ShipBase shipBase, bool expectedResult)
    {
        var obstacles = new List<ObstacleBase>() { new PhotoneFlash() };
        var environment = new HighDensitySpaceNebulae(obstacles);
        var pathSegment = new PathSegment(environment, 100);
        var route = new RouteClass(new List<PathSegment> { pathSegment });

        TotalStatistics totalStatistics = ShipObstacleCollision.ShipObstacleCollisionMethod(shipBase, route);

        Assert.Equal(expectedResult, totalStatistics.CrewIsAlive);
    }
}