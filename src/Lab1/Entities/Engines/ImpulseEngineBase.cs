namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class ImpulseEngineBase : EngineBase
{
    protected double FuelToGetStarted { get; } = 10;
}