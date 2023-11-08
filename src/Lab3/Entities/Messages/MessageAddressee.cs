using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class MessageAddressee : Message
{
    public MessageAddressee(Message customisedMessage)
    {
        CustomisedMessage = customisedMessage;
        ReadState = false;
    }

    public bool ReadState { get; private set; }
    public Message CustomisedMessage { get; }

    public void ReadMessage()
    {
        if (ReadState == true)
        {
            throw new ReadMessageException("!Message has already been read!");
        }

        ReadState = true;
    }
}