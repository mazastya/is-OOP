using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Sender
{
    private readonly IAddressee _addressee;
    private readonly IEnumerable<Topic> _topics;

    public Sender(IEnumerable<Topic> topics, IAddressee addressee)
    {
        _topics = topics;
        _addressee = addressee;
    }

    public void SendMessageSender(Message message, string topicTitle)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(topicTitle);
        Topic? findTopicTitle =
            _topics.FirstOrDefault(topic => topic.Title.Equals(topicTitle, StringComparison.OrdinalIgnoreCase));
        _addressee.Receive(message);
    }
}