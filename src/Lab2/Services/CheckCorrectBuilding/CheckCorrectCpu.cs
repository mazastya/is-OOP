using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;

public class CheckCorrectCpu : ICheckCorrectBuilding
{
    public void CheckCorrectBuilding(ComputerBuilder computerBuilder)
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
}