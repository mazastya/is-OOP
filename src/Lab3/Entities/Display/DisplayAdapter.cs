using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class DisplayAdapter : IAddressee
{
    public DisplayAdapter(IDisplay display)
    {
        Display = display;
    }

    private IDisplay Display { get; }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Display.PrintColorText(message.Title + '\n' +
                               message.LevelOfImportance + '\n' +
                               message.BodyText + '\n');
    }
}