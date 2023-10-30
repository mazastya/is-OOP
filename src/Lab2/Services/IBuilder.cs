using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.NecessaryComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IBuilder
{
    IBuilder WithMotherboard(Motherboard motherboardName);
    IBuilder WithCpu(Cpu cpuName);

    IBuilder WithBios(Bios biosName);
    IBuilder WithProcessorCoolingSystem(ProcessorCoolingSystem processorCoolingSystemName);
    IBuilder WithRam(Ram ramName);
    IBuilder WithPowerPack(PowerPack powerPackName);

    Computer? BuildComputer(IEnumerable<ICheckCorrectBuilding> validators);
}