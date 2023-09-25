using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class EngineTest
{
    [Fact]
    public void TestSpeedEngine()
    {
        // Arrange
        EngineBase engineBase1 = new ImpulseEngineClassC();

        EngineBase engineBase2 = new ImpulseEngineClassE();

        EngineBase jumpEngine = new JumpEngines(TypesOfJumpEngines.AlphaJumpEngine);

        EngineBase jumpEngine2 = new JumpEngines(TypesOfJumpEngines.GammaJumpEngine);

        EngineBase jumpEngine3 = new JumpEngines(TypesOfJumpEngines.OmegaJumpEngine);

        // Act
        double impulseCFuel = engineBase1.HowMuchFuelIsSpentOnTheJourney(100);

        double impulseEFuel = engineBase2.HowMuchFuelIsSpentOnTheJourney(100);

        double jumpAplhaFuel = jumpEngine.HowMuchFuelIsSpentOnTheJourney(100);

        double jumpGammaFuel = jumpEngine2.HowMuchFuelIsSpentOnTheJourney(100);

        double jumpOmegaFuel = jumpEngine3.HowMuchFuelIsSpentOnTheJourney(100);

        // Assert
        Assert.True(impulseEFuel > impulseCFuel);
        Assert.True(jumpGammaFuel > jumpAplhaFuel);

        // Assert.True(jumpOmegaFuel > jumpGammaFuel);
        Assert.True(jumpOmegaFuel > jumpAplhaFuel);
    }
}