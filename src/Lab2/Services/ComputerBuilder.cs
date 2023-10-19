using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder : IBuilder
{
    public ComputerBuilder()
    {
    }

    public IBuilder ComputerMotherboardBuilder(string motherboardName)
    {
        throw new System.NotImplementedException();
    }

    public IBuilder ComputerCorpusBuilder(string corpusName)
    {
        throw new System.NotImplementedException();
    }

    public IBuilder ComputerCpuBuilder(string cpuName)
    {
        throw new System.NotImplementedException();
    }

    public IBuilder ComputerBiosBuilder(string biosName)
    {
        throw new System.NotImplementedException();
    }

    public IBuilder ComputerProcessorCoolingSystemBuilder(string processorCoolingSystemName)
    {
        throw new System.NotImplementedException();
    }

    public IBuilder ComputerRamBuilder(string ramName)
    {
        throw new System.NotImplementedException();
    }

    public IBuilder ComputerPowerPackBuilder(string powerPackName)
    {
        throw new System.NotImplementedException();
    }

    public Computer BuildComputer()
    {
        throw new System.NotImplementedException();
    }
}