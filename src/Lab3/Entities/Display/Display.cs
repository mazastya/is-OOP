using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class Display : IDisplay
{
    public Color Color { get; set; }
    private string TextToDisplay { get; set; } = string.Empty;

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