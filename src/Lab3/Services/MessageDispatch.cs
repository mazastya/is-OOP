using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class MessageDispatch : IAddressee
{
    private readonly IEnumerable<IAddressee> _addressees;

    public MessageDispatch(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        foreach (IAddressee addressee in _addressees)
        {
            addressee.Receive(message);
        }
    }
}