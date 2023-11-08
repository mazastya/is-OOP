using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class UserAddressee : IAddressee
{
    private readonly List<MessageAddressee> _messagesAdapters = new List<MessageAddressee>();
    public IEnumerable<MessageAddressee> MessageAdapters => _messagesAdapters;

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messagesAdapters.Add(new MessageAddressee(message));
    }
}