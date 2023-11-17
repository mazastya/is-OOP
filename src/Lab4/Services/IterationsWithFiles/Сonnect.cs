using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class Сonnect : Command
{
    public Сonnect(string pathFile, IFileSystem fileSystem, string mode)
        : base(pathFile)
    {
        FileSystem = fileSystem;
        Mode = mode;
    }

    private IFileSystem FileSystem { get; set; }
    private string Mode { get; set; }

    public override void Execute(string pathFile)
    {
        FileSystem.Connect(pathFile, Mode);
    }
}