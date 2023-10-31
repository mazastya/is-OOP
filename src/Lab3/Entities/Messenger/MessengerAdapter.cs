using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messanger;

public class MessengerAdapter : IAddressee
{
    public MessengerAdapter(IMessenger messenger)
    {
        Messenger = messenger;
    }

    private IMessenger Messenger { get; }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        Messenger.PrintText(message.Title + '\n' +
                            message.LevelOfImportance + '\n' +
                            message.BodyText + '\n');
    }
}