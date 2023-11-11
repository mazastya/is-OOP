using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class MoveFile : Command
{
    public MoveFile(MyFile myFile, string newPathFile)
        : base(myFile)
    {
        NewPathFile = newPathFile;
    }

    private string NewPathFile { get; set; }

    public override void Execute(MyFile myFile)
    {
        File.Move(myFile.PathFile, NewPathFile);
    }
}