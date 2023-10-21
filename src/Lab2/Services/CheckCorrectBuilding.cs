using System;
using System.Net.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

public class CheckCorrectBuilding<T> : ICheckCorrectBuilding<T>
{
    public void CheckCorrectCorpus(ComputerBuilder<T> computerBuilder)
    {
        ArgumentNullException.ThrowIfNull(computerBuilder);

        if (computerBuilder.Corpus != null && computerBuilder.Motherboard != null &&
            computerBuilder.Corpus.TypeOfCorpus !=
            (TypeOfCorpus)computerBuilder.Motherboard.TypeOfFormFactorMotherboard)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message = "Motherboard form factor and corpus form factor are not equal";
        }
    }

    public void CheckCorrectCpu(ComputerBuilder<T> computerBuilder)
    {
        ArgumentNullException.ThrowIfNull(computerBuilder);
        if (computerBuilder.Motherboard == null)
        {
            throw new ArgumentException("A motherboard is required before installing the CPU", nameof(computerBuilder));
        }

        if (computerBuilder.Cpu?.Socket != computerBuilder.Motherboard.Socket)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message = "Motherboard socket and CPU socket are not equal";
        }
    }

    public void CheckCorrectBios(ComputerBuilder<T> computerBuilder)
    {
        ArgumentNullException.ThrowIfNull(computerBuilder);
        if (computerBuilder.Motherboard == null)
        {
            throw new ArgumentException(
                "The bios is installed after the motherboard is installed",
                nameof(computerBuilder));
        }

        if (computerBuilder.Bios?.Type != computerBuilder.Motherboard.Pair.TypeBios)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message = "Bios type does not match the supported motherboard type";
        }

        if (computerBuilder.Bios != null && computerBuilder.Bios.Version != computerBuilder.Motherboard.Pair.VersionBios)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message = "Bios version does not match the supported motherboard version";
        }
    }

    public void CheckCorrectProcessorCoolingSystem(ComputerBuilder<T> computerBuilder)
    {
        ArgumentNullException.ThrowIfNull(computerBuilder);
        if (computerBuilder.Cpu == null)
        {
            throw new ArgumentException(
                "The processor of cooling system is installed after the motherboard is installed",
                nameof(computerBuilder));
        }

        if (computerBuilder.Bios == null)
        {
            throw new ArgumentException(
                "The processor of cooling system is installed after the motherboard with bios is installed",
                nameof(computerBuilder));
        }

        if (computerBuilder.ProcessorCoolingSystem != null &&
            computerBuilder.ProcessorCoolingSystem.Tdp <= computerBuilder.Cpu.Tdp)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.WorksWithoutWarrantyService;
            computerBuilder.BuilderResult.ComputerCanBeStarted = true;
            computerBuilder.BuilderResult.Message =
                "WARNING! CPU heat dissipation is greater than the heat dissipation " +
                "absorbed by the cooler, causing the computer to overheat and shut down";
        }

        if (computerBuilder.ProcessorCoolingSystem != null &&
            !computerBuilder.ProcessorCoolingSystem.ListOfSupportedSockets.Contains(computerBuilder.Cpu.Socket))
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message = "Processor cooling system socket and CPU socket are not equal";
        }
    }

    public void CheckCorrectRam(ComputerBuilder<T> computerBuilder)
    {
        ArgumentNullException.ThrowIfNull(computerBuilder);

        // if (computerBuilder.Cpu?.ListOfSupportedRFrequenciesRam != null &&
        //     computerBuilder.Ram?.Pair.JedecOfRam != null &&
        //     !Equals(computerBuilder.Ram.Pair.JedecOfRam, computerBuilder.Cpu?.ListOfSupportedRFrequenciesRam))
        // {
        //     computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.WorksWithoutWarrantyService;
        //     computerBuilder.BuilderResult.ComputerCanBeStarted = true;
        //     computerBuilder.BuilderResult.Message =
        //         "CPU supported frequencies of RAM and Ram JEDEC frequencies are not equal";
        // }
        if (computerBuilder.Motherboard?.SupportedStandartOfDdr != null &&
            computerBuilder.Ram?.DdrStandardVersion != null &&
            computerBuilder.Ram.DdrStandardVersion != computerBuilder.Motherboard.SupportedStandartOfDdr)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message =
                "Motherboard supported standard of DDR and Ram standard version of DDR are not equal";
        }
    }

    public void CheckCorrectPowerPack(ComputerBuilder<T> computerBuilder)
    {
        ArgumentNullException.ThrowIfNull(computerBuilder);

        if (computerBuilder.PowerPack != null && computerBuilder.Ram != null &&
            computerBuilder.PowerPack.PeakLoad <= computerBuilder.Ram.PowerConsumed)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message =
                "RAM consumption is higher than the possible power supply consumption";
        }
    }
}