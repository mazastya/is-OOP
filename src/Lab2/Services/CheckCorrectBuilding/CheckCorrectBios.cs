using System;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;

public class CheckCorrectBios : ICheckCorrectBuilding
{
    public void CheckCorrectBuilding(ComputerBuilder computerBuilder)
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

        if (computerBuilder.Bios != null &&
            computerBuilder.Bios.Version != computerBuilder.Motherboard.Pair.VersionBios)
        {
            computerBuilder.BuilderResult.BuilderResultStatusType = BuilderResultStatusType.UnsuccessfulBuild;
            computerBuilder.BuilderResult.ComputerCanBeStarted = false;
            computerBuilder.BuilderResult.Message = "Bios version does not match the supported motherboard version";
        }
    }
}