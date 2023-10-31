using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class MessageAdapter : Message
{
    public MessageAdapter(Message customisedMessage)
    {
        CustomisedMessage = customisedMessage;
        ReadState = false;
    }

    public bool ReadState { get; protected set; }
    protected Message CustomisedMessage { get; }

    public void ReadMessage()
    {
        if (ReadState == true)
        {
            throw new ReadMessageException("!Message has already been read!");
        }

        ReadState = true;
    }
}