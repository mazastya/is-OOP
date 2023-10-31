using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class Message
{
    public string Title { get; protected set; } = string.Empty;
    public string BodyText { get; protected set; } = string.Empty;
    public LevelOfImportance LevelOfImportance { get; set; }
}