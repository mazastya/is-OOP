using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class MoveFile : ICommand
{
    private readonly string _pathFile;
    private readonly string _newPathFile;

    public MoveFile(string pathFile, string newPathFile)
    {
        _pathFile = pathFile;
        _newPathFile = newPathFile;
    }

    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.FileMove(
                   sourcePath: _pathFile,
                   destinationPath: _newPathFile).Status
               == FileResultType.Success
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}