using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Sender
{
    private readonly IEnumerable<Topic> _topics;

    public Sender(IEnumerable<Topic> topics)
    {
        _topics = topics;
    }

    public void SendMessageSender(Message message, string topicTitle)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(topicTitle);
        Topic? findTopicTitle =
            _topics.FirstOrDefault(topic => topic.Title.Equals(topicTitle, StringComparison.OrdinalIgnoreCase));
        findTopicTitle?.SendMessage(message);
    }
}