using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;

public class CheckCorrectPowerPack : ICheckCorrectBuilding
{
    public void CheckCorrectBuilding(ComputerBuilder<string> computerBuilder)
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