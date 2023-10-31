using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

public class Topic : ITopic
{
    private readonly IAddressee _addressee;

    public Topic(
        string name,
        IAddressee addressee)
    {
        _addressee = addressee;
        Name = name;
    }

    public string Name { get; }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _addressee.Receive(message);
    }
}