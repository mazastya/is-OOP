using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class WriterLogger : ILogger
{
    public WriterLogger(string filePath)
    {
        FilePath = filePath;
    }

    public string FilePath { get; }

    public void Log(string messageLog)
    {
        ArgumentNullException.ThrowIfNull(messageLog);
        File.AppendAllText(FilePath, messageLog + "\n");
    }
}