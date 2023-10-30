using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.NecessaryComponents;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public abstract class ComputerBuilder : IBuilder // convenience builder???
{
    public Motherboard? Motherboard { get; set; }
    public Corpus? Corpus { get; set; }
    public Cpu? Cpu { get; set; }

    public Bios? Bios { get; set; }
    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; set; }
    public Ram? Ram { get; set; }
    public PowerPack? PowerPack { get; set; }

    public BuilderResult BuilderResult { get; set; } = new BuilderResult();

    public abstract IBuilder WithMotherboard(Motherboard motherboardName);
    public abstract IBuilder WithCpu(Cpu cpuName);

    public abstract IBuilder WithBios(Bios biosName);
    public abstract IBuilder WithProcessorCoolingSystem(ProcessorCoolingSystem processorCoolingSystemName);
    public abstract IBuilder WithRam(Ram ramName);
    public abstract IBuilder WithPowerPack(PowerPack powerPackName);
    public Computer? BuildComputer(IEnumerable<ICheckCorrectBuilding> validators)
    {
        throw new System.NotImplementedException();
    }

    public abstract Computer? BuildComputer();
}