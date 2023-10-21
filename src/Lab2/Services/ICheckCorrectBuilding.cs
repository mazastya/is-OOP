namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface ICheckCorrectBuilding<T>
{
    public void CheckCorrectCorpus(ComputerBuilder<T> computerBuilder);
    public void CheckCorrectCpu(ComputerBuilder<T> computerBuilder);
    public void CheckCorrectBios(ComputerBuilder<T> computerBuilder);
    public void CheckCorrectProcessorCoolingSystem(ComputerBuilder<T> computerBuilder);
    public void CheckCorrectRam(ComputerBuilder<T> computerBuilder);
    public void CheckCorrectPowerPack(ComputerBuilder<T> computerBuilder);
}