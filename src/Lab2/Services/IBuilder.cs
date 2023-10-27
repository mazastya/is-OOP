using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IBuilder
{
    IBuilder ComputerMotherboardBuilder(string motherboardName);
    IBuilder ComputerCpuBuilder(string cpuName);

    IBuilder ComputerBiosBuilder(string biosName);
    IBuilder ComputerProcessorCoolingSystemBuilder(string processorCoolingSystemName);
    IBuilder ComputerRamBuilder(string ramName);
    IBuilder ComputerPowerPackBuilder(string powerPackName);

    Computer? BuildComputer(IEnumerable<ICheckCorrectBuilding> validators);
}