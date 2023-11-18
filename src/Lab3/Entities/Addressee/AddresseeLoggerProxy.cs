using System;
using Castle.Core.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;

public class AddresseeLoggerProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public AddresseeLoggerProxy(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _logger.CreateChildLogger(message.Title + '\n' +
                    message.LevelOfImportance + '\n' +
                    message.BodyText + '\n');
        _addressee.Receive(message);
    }
}