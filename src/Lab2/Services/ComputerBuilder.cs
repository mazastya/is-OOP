using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public abstract class ComputerBuilder<T> : IBuilder<T> // convenience builder???
{
    public Motherboard? Motherboard { get; set; }
    public Corpus? Corpus { get; set; }
    public Cpu? Cpu { get; set; }

    public Bios? Bios { get; set; }
    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; set; }
    public Ram? Ram { get; set; }
    public PowerPack? PowerPack { get; set; }

    public BuilderResult BuilderResult { get; set; } = new BuilderResult();

    public abstract IBuilder<T> ComputerMotherboardBuilder(string motherboardName);
    public abstract IBuilder<T> ComputerCpuBuilder(string cpuName);

    public abstract IBuilder<T> ComputerBiosBuilder(string biosName);
    public abstract IBuilder<T> ComputerProcessorCoolingSystemBuilder(string processorCoolingSystemName);
    public abstract IBuilder<T> ComputerRamBuilder(string ramName);
    public abstract IBuilder<T> ComputerPowerPackBuilder(string powerPackName);
    public abstract Computer? BuildComputer();
}