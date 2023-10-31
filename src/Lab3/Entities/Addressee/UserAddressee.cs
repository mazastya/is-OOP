using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class UserAddressee : IAddressee
{
    private readonly List<MessageAdapter> _messagesAdapters = new List<MessageAdapter>();
    public IEnumerable<MessageAdapter> MessageAdapters => _messagesAdapters;

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messagesAdapters.Add(new MessageAdapter(message));
    }
}