using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class DeleteFile : Command
{
    public DeleteFile(string pathFile)
        : base(pathFile)
    {
    }

    public override void Execute(string pathFile)
    {
        File.Delete(pathFile);
    }
}