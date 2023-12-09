using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class ShowFile : ICommand
{
    private readonly string _pathFile;
    private readonly string _mode;

    public ShowFile(string pathFile, string mode)
    {
        _pathFile = pathFile;
        _mode = mode;
    }

    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        string? output = context.FileSystem.FileShow(_pathFile, _mode);
        if (_mode == "console")
        {
            new ConsoleOutput().Output(output);
        }
        else if (_mode == "file")
        {
            new FileTxtOutput(_pathFile).Output(output);
        }
        else
        {
            return new FileResult(FileResultType.Failure);
        }

        return new FileResult(FileResultType.Success);
    }
}