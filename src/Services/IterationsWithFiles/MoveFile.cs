using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class MoveFile : Command
{
    public MoveFile(string pathFile, string newPathFile)
        : base(pathFile)
    {
        NewPathFile = newPathFile;
    }

    private string NewPathFile { get; set; }

    public override void Execute(string pathFile)
    {
        File.Move(pathFile, NewPathFile, true);
    }
}