using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class MoveFile(string pathFile, string newPathFile) : ICommand
{
    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.FileMove(
                   sourcePath: pathFile,
                   destinationPath: newPathFile).Status
               == FileResultType.Success
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}