using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class CopyFile(string pathFile, string newPathFile) : ICommand
{
    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.FileCopy(
                   sourcePath: pathFile,
                   destinationPath: newPathFile).Status
               == FileResultType.Success
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}