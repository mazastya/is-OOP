using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerDetailsFactory
{
    public Motherboard CreateMotherboardByName(string motherboardName);
    public Corpus CreateCorpusByName(string corpusName);
    public Cpu CreateCpuByName(string cpuName);
    public Bios CreateBiosByName(string biosName);
    public ProcessorCoolingSystem CreateProcessorCoolingSystemByName(string processorCoolingSystemName);
    public Ram CreateRamByName(string ramName);
    public PowerPack CreatePowerPackByName(string powerPackName);
}