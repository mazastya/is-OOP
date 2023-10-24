using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IBuilder<T>
{
    IBuilder<T> ComputerMotherboardBuilder(string motherboardName);
    IBuilder<T> ComputerCpuBuilder(string cpuName);

    IBuilder<T> ComputerBiosBuilder(string biosName);
    IBuilder<T> ComputerProcessorCoolingSystemBuilder(string processorCoolingSystemName);
    IBuilder<T> ComputerRamBuilder(string ramName);
    IBuilder<T> ComputerPowerPackBuilder(string powerPackName);

    Computer? BuildComputer();
}