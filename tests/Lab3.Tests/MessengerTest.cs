using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messanger;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topics;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;
using Moq;
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
        Assert.Single(user.MessageAdapters);
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
        Assert.True(user.MessageAdapters.All(userMessage => !userMessage.ReadState));
    }

    [Fact]
    public void TestUserReadsAnAlreadyReadMessage()
    {
        // Arrange
        var message = new MessageAdapter(new DirectedMessage("title", LevelOfImportance.MediumImportance));
        var user = new UserAddressee();
        var topic = new Topic("Topic Title", user);

        // Act
        topic.SendMessage(message);
        message.ReadMessage();

        // Assert
        Assert.False(user.MessageAdapters.All(userMessage => userMessage.ReadState));
    }

    [Fact]
    public void TestDisplay()
    {
        // Arrange
        var logger = new Mock<ILogger>();
        var display = new Display();
        var topic = new Topic("Title", new DisplayAdapter(display));

        display.Color = Color.Aqua;

        // Act
        topic.SendMessage(new Message());

        // Assert
        logger.Verify(mock => mock.Log(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void TestLoggerMoq()
    {
        // Arrange
        var message = new Mock<Message>();
        var logger = new Mock<ILogger>();
        var messenger = new Messenger(logger.Object);

        var topic = new Topic("Title", new MessengerAdapter(messenger));

        // Act
        topic.SendMessage(message.Object);

        // Assert
        logger.Verify(mock => mock.Log(It.IsRegex("MESSENGER")), Times.Once);
    }

    [Fact]
    public void TestUserReadsAnAlreadyReadMessageSender()
    {
        // Arrange
        var message = new MessageAdapter(new DirectedMessage("title", LevelOfImportance.MediumImportance));
        var user = new UserAddressee();
        var topic = new Topic("Topic Title", user);
        var topic2 = new Topic("Topic2 Title", user);
        IEnumerable<Topic> topics = new List<Topic>() { topic, topic2 };
        var sender = new Sender(topics, user);

        // Act
        sender.SendMessageSender(message, "Topic Title");
        message.ReadMessage();

        // Assert
        Assert.False(user.MessageAdapters.All(userMessage => userMessage.ReadState));
    }

    [Fact]
    public void TestUserReadsAnAlreadyReadMessageSenderWithAnotherTitile()
    {
        // Arrange
        var message = new MessageAdapter(new DirectedMessage("title", LevelOfImportance.MediumImportance));
        var user = new UserAddressee();
        var topic = new Topic("Topic Title", user);
        var topic2 = new Topic("Topic2 Title", user);
        IEnumerable<Topic> topics = new List<Topic>() { topic, topic2 };
        var sender = new Sender(topics, user);

        // Act
        sender.SendMessageSender(message, "Topic2 Title");
        message.ReadMessage();

        // Assert
        Assert.False(user.MessageAdapters.All(userMessage => userMessage.ReadState));
    }
}