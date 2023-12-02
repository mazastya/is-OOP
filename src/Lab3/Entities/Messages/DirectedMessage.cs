using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

public class DirectedMessage : Message
{
    public DirectedMessage(
        string title,
        LevelOfImportance levelOfImportance)
    {
        Title = title;
        LevelOfImportance = levelOfImportance;
    }
}