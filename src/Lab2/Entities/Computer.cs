using System;
using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.DetailFactories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
    private Computer(
        Motherboard? motherboard,
        Corpus? corpus,
        Cpu? cpu,
        Bios? bios,
        ProcessorCoolingSystem? processorCoolingSystem,
        Ram? ram,
        PowerPack? powerPack)
    {
        Motherboard = motherboard;
        Corpus = corpus;
        Cpu = cpu;
        Bios = bios;
        ProcessorCoolingSystem = processorCoolingSystem;
        Ram = ram;
        PowerPack = powerPack;
    }

    public Motherboard? Motherboard { get; }
    public Corpus? Corpus { get; }
    public Cpu? Cpu { get; }
    public Bios? Bios { get; }
    public ProcessorCoolingSystem? ProcessorCoolingSystem { get; }
    public Ram? Ram { get; }
    public PowerPack? PowerPack { get; }

    [SuppressMessage("", "CA1034", Justification = "Builder")] // заглушка
    public class BuilderComputerClass : ComputerBuilder<string>
    {
        private readonly ComputerDetailsFactory _computerDetailsFactory;

        public BuilderComputerClass(
            ComputerDetailsFactory computerDetailsFactory)
        {
            _computerDetailsFactory = computerDetailsFactory;

            // MotherboardFactory = motherboardFactory ?? throw new ArgumentNullException(nameof(motherboardFactory));
            // CorpusFactory = corpusFactory ?? throw new ArgumentNullException(nameof(corpusFactory));
            // CpuFactory = cpuFactory ?? throw new ArgumentNullException(nameof(cpuFactory));
            // ProcessorCoolingSystemFactory = processorCoolingSystemFactory ??
            //                                 throw new ArgumentNullException(nameof(processorCoolingSystemFactory));
            // RamFactory = ramFactory ?? throw new ArgumentNullException(nameof(ramFactory));
            // PowerPackFactory = powerPackFactory ?? throw new ArgumentNullException(nameof(powerPackFactory));
        }

        // public IFactory<Motherboard> MotherboardFactory { get; }
        // public IFactory<Corpus> CorpusFactory { get; }
        // public IFactory<Cpu> CpuFactory { get; }
        // public IFactory<Bios> BiosFactory { get; }
        // public IFactory<ProcessorCoolingSystem> ProcessorCoolingSystemFactory { get; }
        // public IFactory<Ram> RamFactory { get; }
        // public IFactory<PowerPack> PowerPackFactory { get; }
        public override IBuilder<string> ComputerMotherboardBuilder(string motherboardName)
        {
            if (motherboardName == null)
            {
                BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
                BuilderResult.ComputerCanBeStarted = false;
                BuilderResult.Message = "Computer cannot operate without the motherboard";
                return this;
            }

            Motherboard = _computerDetailsFactory.CreateMotherboardByName(motherboardName);
            return this;
        }

        public override IBuilder<string> ComputerCorpusBuilder(string corpusName)
        {
            if (corpusName == null)
            {
                BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
                BuilderResult.ComputerCanBeStarted = false;
                BuilderResult.Message = "Computer cannot operate without the corpus";
                return this;
            }

            var checkSetCorpus = new CheckCorrectBuilding<string>();
            Corpus = _computerDetailsFactory.CreateCorpusByName(corpusName);
            checkSetCorpus.CheckCorrectCorpus(this);
            return this;
        }

        public override IBuilder<string> ComputerCpuBuilder(string cpuName)
        {
            if (cpuName == null)
            {
                BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
                BuilderResult.ComputerCanBeStarted = false;
                BuilderResult.Message = "Computer cannot operate without the CPU";
                return this;
            }

            var checkSetCpu = new CheckCorrectBuilding<string>();
            Cpu = _computerDetailsFactory.CreateCpuByName(cpuName);
            checkSetCpu.CheckCorrectCpu(this);
            return this;
        }

        public override IBuilder<string> ComputerBiosBuilder(string? biosName)
        {
            if (biosName == null)
            {
                BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
                BuilderResult.ComputerCanBeStarted = false;
                BuilderResult.Message = "Computer cannot operate without the BIOS";
                return this;
            }

            var checkSetBios = new CheckCorrectBuilding<string>();
            Bios = _computerDetailsFactory.CreateBiosByName(biosName);
            checkSetBios.CheckCorrectBios(this);
            return this;
        }

        public override IBuilder<string> ComputerProcessorCoolingSystemBuilder(string processorCoolingSystemName)
        {
            if (processorCoolingSystemName == null)
            {
                BuilderResult.BuilderResultStatusType = BuilderResultStatusType.WorksWithoutWarrantyService;
                BuilderResult.ComputerCanBeStarted = true;
                BuilderResult.Message = "Computer has no cooling system, the processor will be overloaded";
                return this;
            }

            var checkSetProcessorCoolingSystem = new CheckCorrectBuilding<string>();
            ProcessorCoolingSystem =
                _computerDetailsFactory.CreateProcessorCoolingSystemByName(processorCoolingSystemName);
            checkSetProcessorCoolingSystem.CheckCorrectProcessorCoolingSystem(this);
            return this;
        }

        public override IBuilder<string> ComputerRamBuilder(string ramName)
        {
            if (ramName == null)
            {
                BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
                BuilderResult.ComputerCanBeStarted = false;
                BuilderResult.Message = "Computer cannot operate without the RAM";
                return this;
            }

            var checkSetRam = new CheckCorrectBuilding<string>();
            Ram = _computerDetailsFactory.CreateRamByName(ramName);
            checkSetRam.CheckCorrectRam(this);
            return this;
        }

        public override IBuilder<string> ComputerPowerPackBuilder(string powerPackName)
        {
            if (powerPackName == null)
            {
                BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
                BuilderResult.ComputerCanBeStarted = false;
                BuilderResult.Message = "Computer cannot operate without the power pack";
                return this;
            }

            var checkSetPowerPack = new CheckCorrectBuilding<string>();
            PowerPack = _computerDetailsFactory.CreatePowerPackByName(powerPackName);
            checkSetPowerPack.CheckCorrectPowerPack(this);
            return this;
        }

        public override Computer? BuildComputer()
        {
            if (BuilderResult.BuilderResultStatusType is BuilderResultStatusType.WorksWithoutWarrantyService ||
                BuilderResult.BuilderResultStatusType is BuilderResultStatusType.Success)
            {
                return new Computer(
                    Motherboard,
                    Corpus,
                    Cpu,
                    Bios,
                    ProcessorCoolingSystem,
                    Ram,
                    PowerPack);
            }

            return default;
        }
    }
}