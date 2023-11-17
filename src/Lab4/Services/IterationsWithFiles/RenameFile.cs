using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class RenameFile : Command
{
    public RenameFile(string pathFile, string newNameFile)
        : base(pathFile)
    {
        PathFile = pathFile;
        NewNameFile = newNameFile;
    }

    private string NewNameFile { get; set; }

    public override void Execute(string pathFile)
    {
        File.Move(pathFile, NewNameFile, true);
    }
}