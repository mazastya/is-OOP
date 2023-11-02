using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class TopicNotFoundException : Exception
{
    public TopicNotFoundException()
    {
    }

    public TopicNotFoundException(string message)
        : base(message)
    {
    }

    public TopicNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}