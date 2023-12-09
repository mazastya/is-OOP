using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class CopyFile : ICommand
{
    private readonly string _pathFile;
    private readonly string _newPathFile;

    public CopyFile(string pathFile, string newPathFile)
    {
        _pathFile = pathFile;
        _newPathFile = newPathFile;
    }

    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.FileCopy(
                   sourcePath: _pathFile,
                   destinationPath: _newPathFile).Status
               == FileResultType.Success
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}