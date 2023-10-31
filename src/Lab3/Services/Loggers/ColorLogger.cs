using System;
using System.Drawing;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class ColorLogger : IDisplay, ILogger
{
    public ColorLogger(string filePath)
    {
        FilePath = filePath;
    }

    public string FilePath { get; }
    public Color Color { get; set; }
    private string TextToDisplay { get; set; } = string.Empty;

    public void Log(string messageLog)
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