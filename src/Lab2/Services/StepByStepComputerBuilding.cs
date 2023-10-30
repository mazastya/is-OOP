using System;
using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class StepByStepComputerBuilding : ComputerBuilder<string>
{
    private readonly IComputerDetailsFactory _computerDetailsFactory;
    private readonly IEnumerable<ICheckCorrectBuilding> _checkers;

    public StepByStepComputerBuilding(
        IComputerDetailsFactory computerDetailsFactory,
        IEnumerable<ICheckCorrectBuilding> checkers)
    {
        _computerDetailsFactory = computerDetailsFactory;
        _checkers = checkers;
    }

    public override IBuilder WithMotherboard(string motherboardName)
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

    public IBuilder ComputerCorpusBuilder(string corpusName)
    {
        if (corpusName == null)
        {
            BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            BuilderResult.ComputerCanBeStarted = false;
            BuilderResult.Message = "Computer cannot operate without the corpus";
            return this;
        }

        Corpus = _computerDetailsFactory.CreateCorpusByName(corpusName);
        return this;
    }

    public override IBuilder WithCpu(string cpuName)
    {
        if (cpuName == null)
        {
            BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            BuilderResult.ComputerCanBeStarted = false;
            BuilderResult.Message = "Computer cannot operate without the CPU";
            return this;
        }

        Cpu = _computerDetailsFactory.CreateCpuByName(cpuName);
        return this;
    }

    public override IBuilder WithBios(string? biosName)
    {
        if (biosName == null)
        {
            BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            BuilderResult.ComputerCanBeStarted = false;
            BuilderResult.Message = "Computer cannot operate without the BIOS";
            return this;
        }

        Bios = _computerDetailsFactory.CreateBiosByName(biosName);
        return this;
    }

    public override IBuilder WithProcessorCoolingSystem(string processorCoolingSystemName)
    {
        if (processorCoolingSystemName == null)
        {
            BuilderResult.BuilderResultStatusType = BuilderResultStatusType.WorksWithoutWarrantyService;
            BuilderResult.ComputerCanBeStarted = true;
            BuilderResult.Message = "Computer has no cooling system, the processor will be overloaded";
            return this;
        }

        ProcessorCoolingSystem =
            _computerDetailsFactory.CreateProcessorCoolingSystemByName(processorCoolingSystemName);
        return this;
    }

    public override IBuilder WithRam(string ramName)
    {
        if (ramName == null)
        {
            BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            BuilderResult.ComputerCanBeStarted = false;
            BuilderResult.Message = "Computer cannot operate without the RAM";
            return this;
        }

        Ram = _computerDetailsFactory.CreateRamByName(ramName);
        return this;
    }

    public override IBuilder WithPowerPack(string powerPackName)
    {
        if (powerPackName == null)
        {
            BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            BuilderResult.ComputerCanBeStarted = false;
            BuilderResult.Message = "Computer cannot operate without the power pack";
            return this;
        }

        PowerPack = _computerDetailsFactory.CreatePowerPackByName(powerPackName);
        return this;
    }

    public override Computer? BuildComputer()
    {
        return BuildComputer(_checkers);
    }

    public new Computer? BuildComputer(IEnumerable<ICheckCorrectBuilding> validators)
    {
        RunCompatibilityCheck(validators);
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

    private void RunCompatibilityCheck(IEnumerable<ICheckCorrectBuilding> validators)
    {
        ArgumentNullException.ThrowIfNull(Corpus);
        ArgumentNullException.ThrowIfNull(Motherboard);
        ArgumentNullException.ThrowIfNull(Cpu);
        ArgumentNullException.ThrowIfNull(ProcessorCoolingSystem);
        ArgumentNullException.ThrowIfNull(Ram);
        ArgumentNullException.ThrowIfNull(PowerPack);

        foreach (ICheckCorrectBuilding checkCorrect in validators)
        {
            checkCorrect.CheckCorrectBuilding(this);
        }
    }
}