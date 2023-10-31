using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messanger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTest
{
    [Fact]
    public void TestUserReceiveMessage()
    {
        // Arrange
        Message message = new DirectedMessage("Title", LevelOfImportance.HighImportance);
        var user = new UserAddressee();
        ITopic topic = new Topic("Title", user);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.Single(user.ReceivedMessages);
    }

    [Fact]
    public void TestReceiveMessageUnreadState()
    {
        // Arrange
        Message message = new DirectedMessage("Title", LevelOfImportance.HighImportance);
        var user = new UserAddressee();
        ITopic topic = new Topic("Title", user);

        // Act
        topic.SendMessage(message);

        // Assert
        Assert.True(user.ReceivedMessages.All(userMessage => !userMessage.ReadState));
    }
}