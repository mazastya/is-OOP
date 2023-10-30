using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IBuilder
{
    IBuilder WithMotherboard(string motherboardName);
    IBuilder WithCpu(string cpuName);

    IBuilder WithBios(string biosName);
    IBuilder WithProcessorCoolingSystem(string processorCoolingSystemName);
    IBuilder WithRam(string ramName);
    IBuilder WithPowerPack(string powerPackName);

    Computer? BuildComputer(IEnumerable<ICheckCorrectBuilding> validators);
}