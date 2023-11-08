using System;
using System.Drawing;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class ColorLogger : IDisplay, ILogger<Message>
{
    public ColorLogger(string filePath)
    {
        FilePath = filePath;
    }

    public Color Color { get; set; }
    private string FilePath { get; }
    private string TextToDisplay { get; set; } = string.Empty;

    public void Log(Message messageLog)
    {
        ArgumentNullException.ThrowIfNull(messageLog);
        File.AppendAllText(FilePath, messageLog + "\n");
    }

    public void PrintColorText(string textBody)
    {
        ArgumentNullException.ThrowIfNull(textBody);
        ClearScreen();
        TextToDisplay = Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(textBody);
    }

    private void ClearScreen()
    {
        Console.Clear();
        TextToDisplay = string.Empty;
    }
}