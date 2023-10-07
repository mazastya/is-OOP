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
                new WalkingShuttle(),
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
                new Vacklas(deflectorBase: new DeflectorClass1()),
                false,
            },

            new object[]
            {
                new Vacklas(deflectorBase: new PhotonDeflectors(new DeflectorClass1())),
                true,
            },
        };

    // initialisation for the second test
    public static IEnumerable<object[]> DataForTest3 =>
        new List<object[]>
        {
            new object[]
            {
                new Vacklas(deflectorBase: new DeflectorClass1()),
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
                ResultOfDamage.SpaceShipIsDestroyed,
            },
        };

    // initialisation for the second test
    public static IEnumerable<object[]> DataForTest7 =>
        new List<object[]>
        {
            new object[]
            {
                new Vacklas(deflectorBase: new DeflectorClass1()),
                false,
            },

            new object[]
            {
                new Vacklas(deflectorBase: new PhotonDeflectors(new DeflectorClass1())),
                true,
            },

            new object[]
            {
                new Stella(),
                false,
            },
        };

    [Theory]
    [MemberData(nameof(DataForTest1))]
    public void TestOneISHighDensityTestShuttleAndAugurth(ShipBase shipBase, ResultOfDamage expectedResult)
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
    public void TestTwoISAThreeShipDeathCheck(ShipBase shipBase, bool expectedResult)
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
    public void TestThreeISCheckingTheCostOfShuttleAndVacklasFlights(ShipBase shipBase, ResultOfDamage expectedResult)
    {
        // Arrange
        var obstacles = new List<ObstacleBase>() { new CosmoWhale() };
        var environment = new NitrinoParticleNebulae(obstacles);
        var pathSegment = new PathSegment(environment, 100);
        var route = new RouteClass(new List<PathSegment> { pathSegment });

        // Act
        TotalStatistics totalStatistics = ShipObstacleCollision.ShipObstacleCollisionMethod(shipBase, route);

        // Assert
        Assert.Equal(expectedResult, totalStatistics.Status);
    }

    [Fact]
    public void TestFourISOrdinaryNebulaeTestShuttleAndVacklas()
    {
        // Arrange
        var walkingShuttle = new WalkingShuttle();
        var vaсklas = new Vacklas(deflectorBase: new DeflectorClass1());

        // var ships = new List<ShipBase> { augur, stella };
        var obstacles = new List<ObstacleBase>();
        var environment = new OrdinarySpace(obstacles);
        var segment = new PathSegment(environment, 1000);

        var route = new RouteClass(new[] { segment });

        // Act
        TotalStatistics totalStatisticsShuttle =
            ShipObstacleCollision.ShipObstacleCollisionMethod(walkingShuttle, route);
        TotalStatistics totalStatisticsVacklas = ShipObstacleCollision.ShipObstacleCollisionMethod(vaсklas, route);

        // Assert
        Assert.True(totalStatisticsShuttle.FuelConsumedToJourney < totalStatisticsVacklas.FuelConsumedToJourney);
    }

    [Fact]
    public void TestFiveISStellaAndAugurRangeJumpTest()
    {
        // Arrange
        var augur = new Augur();
        var stella = new Stella();

        var ships = new List<ShipBase> { augur, stella };

        var obstacles = new List<ObstacleBase>();
        var environment = new HighDensitySpaceNebulae(obstacles);
        var segment = new PathSegment(environment, 5000);

        var route = new RouteClass(new[] { segment });

        // Act
        TotalStatistics totalStatisticsAugur = ShipObstacleCollision.ShipObstacleCollisionMethod(augur, route);
        TotalStatistics totalStatisticsStella = ShipObstacleCollision.ShipObstacleCollisionMethod(stella, route);
        ShipBase? optimalShip = ShipObstacleCollision.FindBestShipForRoute(ships, route);

        // Assert
        Assert.False(totalStatisticsStella.FuelConsumedToJourney < totalStatisticsAugur.FuelConsumedToJourney);
        Assert.Equal(stella, optimalShip);
    }

    [Fact]
    public void TestSixISNitrinoParticlesTestShuttleAndVacklas()
    {
        // Arrange
        var walkingShuttle = new WalkingShuttle();
        var vacklas = new Vacklas(deflectorBase: new DeflectorClass1());

        var ships = new List<ShipBase> { walkingShuttle, vacklas };

        var obstacles = new List<ObstacleBase>();
        var environment = new NitrinoParticleNebulae(obstacles);
        var segment = new PathSegment(environment, 1000);

        var route = new RouteClass(new[] { segment });

        // Act
        TotalStatistics totalStatisticShuttle =
            ShipObstacleCollision.ShipObstacleCollisionMethod(walkingShuttle, route);
        TotalStatistics totalStatisticsVacklas = ShipObstacleCollision.ShipObstacleCollisionMethod(vacklas, route);
        ShipBase? optimalShip = ShipObstacleCollision.FindBestShipForRoute(ships, route);

        // Assert
        Assert.True(totalStatisticsVacklas.FuelConsumedToJourney > totalStatisticShuttle.FuelConsumedToJourney);
        Assert.Equal(walkingShuttle, optimalShip);
    }

    [Theory]
    [MemberData(nameof(DataForTest7))]
    public void TestSevenISTheTeamSurvivesWithAPhotonDeflector(ShipBase shipBase, bool expectedResult)
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
}