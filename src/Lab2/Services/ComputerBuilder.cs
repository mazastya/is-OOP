using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.NecessaryComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public abstract class ComputerBuilder<T> : IBuilder // convenience builder???
{
    public Motherboard? Motherboard { get; set; }
    public Corpus? Corpus { get; set; }
    public Cpu? Cpu { get; set; }

    public Bios? Bios { get; set; }
    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; set; }
    public Ram? Ram { get; set; }
    public PowerPack? PowerPack { get; set; }

    public BuilderResult BuilderResult { get; set; } = new BuilderResult();

    public abstract IBuilder ComputerMotherboardBuilder(string motherboardName);
    public abstract IBuilder ComputerCpuBuilder(string cpuName);

    public abstract IBuilder ComputerBiosBuilder(string biosName);
    public abstract IBuilder ComputerProcessorCoolingSystemBuilder(string processorCoolingSystemName);
    public abstract IBuilder ComputerRamBuilder(string ramName);
    public abstract IBuilder ComputerPowerPackBuilder(string powerPackName);
    public Computer? BuildComputer(IEnumerable<ICheckCorrectBuilding> validators)
    {
        throw new System.NotImplementedException();
    }

    public abstract Computer? BuildComputer();
}