namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(
        string title,
        string bodyText,
        string levelOfImportant)
    {
        Title = title;
        BodyText = bodyText;
        LevelOfImportant = levelOfImportant;
    }

    public string Title { get; set; }
    public string BodyText { get; set; }
    private string LevelOfImportant { get; set; }
}