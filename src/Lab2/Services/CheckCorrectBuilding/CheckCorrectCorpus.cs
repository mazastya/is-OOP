using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.CheckCorrectBuilding;

public class CheckCorrectCorpus : ICheckCorrectBuilding
{
    public void CheckCorrectBuilding(ComputerBuilder<string> computerBuilder)
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
}