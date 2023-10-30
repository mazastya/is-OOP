using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;

public class CheckCorrectRam : ICheckCorrectBuilding
{
    public void CheckCorrectBuilding(ComputerBuilder computerBuilder)
    {
        ArgumentNullException.ThrowIfNull(computerBuilder);

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
}