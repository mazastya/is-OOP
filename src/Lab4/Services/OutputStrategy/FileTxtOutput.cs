using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.OutputStrategy;

public class FileTxtOutput : IOutputStrategy
{
    private readonly string _filePath;

    public FileTxtOutput(string filePath)
    {
        _filePath = filePath;
    }

    public void Output(string output)
    {
        File.WriteAllText(_filePath, output);
    }
}