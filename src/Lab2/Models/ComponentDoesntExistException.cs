using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComponentDoesntExistException : Exception
{
    public ComponentDoesntExistException(string message)
        : base(message)
    {
    }

    public ComponentDoesntExistException()
    {
    }

    public ComponentDoesntExistException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}