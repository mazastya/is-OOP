using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;

public class CheckCorrectProcessorCoolingSystem : ICheckCorrectBuilding
{
    public void CheckCorrectBuilding(ComputerBuilder computerBuilder)
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
}