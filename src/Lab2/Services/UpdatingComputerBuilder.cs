using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class UpdatingComputerBuilder<T> : ComputerBuilder<T>
{
    public new Bios? Bios { get; protected set; }

    public override IBuilder<T> ComputerMotherboardBuilder(string motherboardName)
    {
        throw new System.NotImplementedException();
    }

    public override IBuilder<T> ComputerCorpusBuilder(string corpusName)
    {
        throw new System.NotImplementedException();
    }

    public override IBuilder<T> ComputerCpuBuilder(string cpuName)
    {
        throw new System.NotImplementedException();
    }

    public override IBuilder<T> ComputerBiosBuilder(string biosName)
    {
        throw new System.NotImplementedException();
    }

    public override IBuilder<T> ComputerProcessorCoolingSystemBuilder(string processorCoolingSystemName)
    {
        throw new System.NotImplementedException();
    }

    public override IBuilder<T> ComputerRamBuilder(string ramName)
    {
        throw new System.NotImplementedException();
    }

    public override IBuilder<T> ComputerPowerPackBuilder(string powerPackName)
    {
        throw new System.NotImplementedException();
    }

    public override Computer? BuildComputer()
    {
        throw new System.NotImplementedException();
    }
}