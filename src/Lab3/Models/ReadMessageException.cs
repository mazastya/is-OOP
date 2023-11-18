using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class ReadMessageException : Exception
{
    public ReadMessageException()
    {
    }

    public ReadMessageException(string message)
        : base(message)
    {
    }

    public ReadMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}