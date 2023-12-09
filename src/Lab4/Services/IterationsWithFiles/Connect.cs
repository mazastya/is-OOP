using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class Connect : ICommand
{
    public Connect(string pathFile, string mode)
    {
        PathFile = pathFile;
        Mode = mode;
    }

    public string PathFile { get; }
    public string Mode { get; }

    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.Connect(PathFile, Mode)
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}