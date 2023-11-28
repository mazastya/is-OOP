using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class ShowFile(string pathFile, string mode) : ICommand
{
    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        string? output = context.FileSystem.FileShow(pathFile, mode);
        if (mode == "console")
        {
            new ConsoleOutput().Output(output);
        }
        else if (mode == "file")
        {
            new FileTxtOutput(pathFile).Output(output);
        }
        else
        {
            return new FileResult(FileResultType.Failure);
        }

        return new FileResult(FileResultType.Success);
    }
}