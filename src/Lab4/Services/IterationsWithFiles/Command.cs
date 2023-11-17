using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public abstract class Command
{
    protected Command(string pathFile)
    {
        PathFile = pathFile;
    }

    public string PathFile { get; set; }

    public abstract void Execute(string pathFile);
}