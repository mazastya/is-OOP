using System;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class Messenger : IMessenger
{
    private readonly ILogger<string> _logger;

    public Messenger(ILogger<string> logger)
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
}