using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class Connect : ICommand
{
    private readonly string _pathFile;
    private readonly string _mode;

    public Connect(string pathFile, string mode)
    {
        _pathFile = pathFile;
        _mode = mode;
    }

    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.Connect(_pathFile, _mode)
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}