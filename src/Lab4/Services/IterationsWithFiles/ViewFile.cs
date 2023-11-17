using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class ViewFile : Command
{
    public ViewFile(string pathFile)
        : base(pathFile)
    {
    }

    public override void Execute(string pathFile)
    {
        File.ReadAllText(pathFile);
    }
}