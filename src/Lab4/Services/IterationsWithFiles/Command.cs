using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public abstract class Command
{
    protected Command(MyFile myFile)
    {
        MyFile = myFile;
    }

    public MyFile MyFile { get; set; }

    public abstract void Execute(MyFile myFile);
}