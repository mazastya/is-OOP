using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class Connect(string pathFile, string mode) : ICommand
{
    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.Connect(pathFile, mode)
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}