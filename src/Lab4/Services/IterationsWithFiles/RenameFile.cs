using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class RenameFile : Command
{
    public RenameFile(MyFile myFile, string newNameFile)
        : base(myFile)
    {
        MyFile = myFile;
        NewNameFile = newNameFile;
    }

    private string NewNameFile { get; set; }

    public override void Execute(MyFile myFile)
    {
        File.Move(MyFile.PathFile, NewNameFile, true);
    }
}