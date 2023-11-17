using System;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Input;
using System.Xml;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exception;
using Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles.ViewFile;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ActCompliteTest
{
    [Fact]
    public void ConnectCommand()
    {
        // Arrange
        string path1 = @"connect C:\Users\amaza\Desktop -m local";
        string[] path = path1.Split(' ');
        var parser = new ConnectFlag();

        // Act
        string ans = parser.HandleRequest(path);

        // Assert
        Assert.Equal("act complete", ans);
    }

    [Fact]
    public void DeleteCommand()
    {
        // Arrange
        string path1 =
            @"file delete D:\Programs_from_installation\Rider\mazastya\src\Lab4\bin\Debug\net7.0\Folder1\test1.txt";
        string[] path = path1.Split(' ');
        var parser = new DeleteFileFlag();

        // Act
        string ans = parser.HandleRequest(path);

        // Assert
        Assert.Equal("act complete", ans);
    }

    [Fact]
    public void DeleteCommandNotExistFile()
    {
        // Arrange
        string path1 =
            @"file delete D:\Programs_from_installation\Rider\mazastya\src\Lab4\bin\Debug\net7.0\Folder1\test1.txt";
        string[] path = path1.Split(' ');
        var parser = new DeleteFileFlag();

        // Act
        string ans = parser.HandleRequest(path);

        // Assert
        Assert.Equal("act complete", ans);
    }
}