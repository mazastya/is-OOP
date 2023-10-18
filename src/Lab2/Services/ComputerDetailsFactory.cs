using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDetailsFactory : IComputerDetailsFactory
{
    private readonly IFactory<Motherboard> _motherboardFactory;
    private readonly IFactory<Corpus> _corpusFactory;
    private readonly IFactory<Cpu> _cpuFactory;
    private readonly IFactory<Bios> _biosFactory;
    private readonly IFactory<ProcessorCoolingSystem> _processorCoolingSysytemFactory;
    private readonly IFactory<Ram> _ramFactory;
    private readonly IFactory<PowerPack> _powerPackFactory;

    public ComputerDetailsFactory(
        IFactory<Motherboard> motherboardFactory,
        IFactory<Corpus> corpusFactory,
        IFactory<Cpu> cpuFactory,
        IFactory<Bios> biosFactory,
        IFactory<ProcessorCoolingSystem> processorCoolingSysytemFactory,
        IFactory<Ram> ramFactory,
        IFactory<PowerPack> powerPackFactory)
    {
        _motherboardFactory = motherboardFactory;
        _corpusFactory = corpusFactory;
        _cpuFactory = cpuFactory;
        _biosFactory = biosFactory;
        _processorCoolingSysytemFactory = processorCoolingSysytemFactory;
        _ramFactory = ramFactory;
        _powerPackFactory = powerPackFactory;
    }

    public Motherboard CreateMotherboardByName(string motherboardName)
    {
        return _motherboardFactory.CreateComponentByName(motherboardName) ??
               throw new ArgumentNullException(nameof(motherboardName));
    }

    public Corpus CreateCorpusByName(string corpusName)
    {
        return _corpusFactory.CreateComponentByName(corpusName) ?? throw new ArgumentNullException(nameof(corpusName));
    }

    public Cpu CreateCpuByName(string cpuName)
    {
        return _cpuFactory.CreateComponentByName(cpuName) ?? throw new ArgumentNullException(nameof(cpuName));
    }

    public Bios CreateBiosByName(string biosName)
    {
        return _biosFactory.CreateComponentByName(biosName) ?? throw new ArgumentNullException(nameof(biosName));
    }

    public ProcessorCoolingSystem CreateProcessorCoolingSystemByName(string processorCoolingSystemName)
    {
        return _processorCoolingSysytemFactory.CreateComponentByName(processorCoolingSystemName) ??
               throw new ArgumentNullException(nameof(processorCoolingSystemName));
    }

    public Ram CreateRamByName(string ramName)
    {
        return _ramFactory.CreateComponentByName(ramName) ?? throw new ArgumentNullException(nameof(ramName));
    }

    public PowerPack CreatePowerPackByName(string powerPackName)
    {
        return _powerPackFactory.CreateComponentByName(powerPackName) ??
               throw new ArgumentNullException(nameof(powerPackName));
    }
}