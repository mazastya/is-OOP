using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplayDriver
{
    string Text { get; }

    void ClearOutput();
    void SetTextBody(string textBody);
    void SetColorForText(Color color);
    string GetColorText();
}