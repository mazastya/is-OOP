namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    public Topic(
        string nameOfTopic,
        string addressee)
    {
        NameOfTopic = nameOfTopic;
        Addressee = addressee;
    }

    public string NameOfTopic { get; set; }
    public string Addressee { get; set; }

    // public Message MessageToAdressee(Message message)
    // {
    //     message.BodyText
    // }
}