using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class DeleteFile : Command
{
    public DeleteFile(MyFile myFile)
        : base(myFile)
    {
    }

    public override void Execute(MyFile myFile)
    {
        File.Delete(myFile.PathFile);
    }
}