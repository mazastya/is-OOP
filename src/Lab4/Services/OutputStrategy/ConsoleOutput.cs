using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

public class ConsoleOutput : IOutputStrategy
{
    public void Output(string output)
    {
        Console.WriteLine(output);
    }
}