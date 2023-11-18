using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class WriterLogger : ILogger<Message>
{
    public WriterLogger(string filePath)
    {
        FilePath = filePath;
    }

    private string FilePath { get; }

    public void Log(Message messageLog)
    {
        ArgumentNullException.ThrowIfNull(messageLog);
        File.AppendAllText(FilePath, messageLog + "\n");
    }
}