using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDetailsFactory : IComputerDetailsFactory
{
    private readonly IFactory<Cpu> _cpuFactory;

    public ComputerDetailsFactory(
        IFactory<Cpu> cpuFactory)
    {
        _cpuFactory = cpuFactory;
    }

    public Cpu? CreateCpuByName(string cpuName)
    {
        return _cpuFactory.CreateComponentByName(cpuName);
    }
}