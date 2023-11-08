using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DisplayDriver : IDisplayDriver
{
    public string Text { get; set; } = string.Empty;
    private Color Color { get; set; }

    public void ClearOutput()
    {
        Text = string.Empty;
    }

    public void SetTextBody(string textBody)
    {
        Text = textBody;
    }

    public void SetColorForText(Color color)
    {
        Color = color;
    }

    public string GetColorText()
    {
        return Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(Text);
    }
}