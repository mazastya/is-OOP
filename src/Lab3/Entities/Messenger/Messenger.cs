using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messanger;

public class Messenger : IMessenger, IAddressee
{
    private readonly ILogger _logger;

    public Messenger(ILogger logger)
    {
        _logger = logger;
    }

    private string TextToMessenger { get; set; } = string.Empty;

    public void PrintText(string textBody)
    {
        ArgumentNullException.ThrowIfNull(textBody);
        TextToMessenger += textBody;
        _logger.Log("MESSENGER" + '\n' + textBody);
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        TextToMessenger = message.BodyText;
    }
}