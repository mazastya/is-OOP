using System;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

public class ConsoleOutput : IOutputStrategy
{
    public void Output(string? output)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine(output);
    }
}