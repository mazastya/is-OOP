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

public class AllNecessaryTests
{
    // initialisation for the first test
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
                new Augur(),
                ResultOfDamage.JumpEngineRangShortfall,
            },
        };

    // initialisation for the second test
    public static IEnumerable<object[]> DataForTest2 =>
        new List<object[]>
        {
            new object[]
            {
                new Vaсklas(deflectorBase: new DeflectorClass1()),
                false,
            },

            new object[]
            {
                new Vaсklas(deflectorBase: new PhotonDeflectors(new DeflectorClass1())),
                true,
            },
        };

    // initialisation for the second test
    public static IEnumerable<object[]> DataForTest3 =>
        new List<object[]>
        {
            new object[]
            {
                new Vaсklas(deflectorBase: new DeflectorClass1()),
                ResultOfDamage.SpaceShipIsDestroyed,
            },

            new object[]
            {
                new Augur(),
                ResultOfDamage.SpaceShipIsDestroyed,
            },

            new object[]
            {
                new Meredian(),
                ResultOfDamage.Success,
            },
        };

    [Theory]
    [MemberData(nameof(DataForTest1))]
    public void TestTryOne(ShipBase shipBase, ResultOfDamage expectedResult)
    {
        // Arange
        var obstacles = new List<ObstacleBase>();
        var environment = new HighDensitySpaceNebulae(obstacles);
        var pathSegment = new PathSegment(environment, 101);
        var route = new RouteClass(new List<PathSegment> { pathSegment });

        // Act
        TotalStatistics totalStatistics = ShipObstacleCollision.ShipObstacleCollisionMethod(shipBase, route);

        // Assert
        Assert.Equal(expectedResult, totalStatistics.Status);
    }

    [Theory]
    [MemberData(nameof(DataForTest2))]
    public void Test2(ShipBase shipBase, bool expectedResult)
    {
        // Arrange
        var obstacles = new List<ObstacleBase>() { new PhotoneFlash() };
        var environment = new HighDensitySpaceNebulae(obstacles);
        var pathSegment = new PathSegment(environment, 100);
        var route = new RouteClass(new List<PathSegment> { pathSegment });

        // Act
        TotalStatistics totalStatistics = ShipObstacleCollision.ShipObstacleCollisionMethod(shipBase, route);

        // Assert
        Assert.Equal(expectedResult, totalStatistics.CrewIsAlive);
    }

    [Theory]
    [MemberData(nameof(DataForTest3))]
}