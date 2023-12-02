using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Models;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class RenameFile : ICommand
{
    private readonly string _pathFile;
    private readonly string _newNameFile;

    public RenameFile(string pathFile, string newNameFile)
    {
        _pathFile = pathFile;
        _newNameFile = newNameFile;
    }

    public FileResult Execute(IContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return context.FileSystem.FileRename(
                   path: _pathFile,
                   _newNameFile).Status
               == FileResultType.Success
            ? new FileResult(FileResultType.Success)
            : new FileResult(FileResultType.Failure);
    }
}