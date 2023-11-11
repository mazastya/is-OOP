using System;
using System.IO;
using System.Xml;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles.ViewFile;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Test
{
    [Fact]
    public void Rename()
    {
        var myFile = new MyFile("test", "D:\\Programs from installation\\Rider\\mazastya\\tests\\Lab4.Tests\\test.txt");
        var renameFile = new RenameFile(myFile, "bfrkjbj");
        renameFile.Execute(myFile);
    }
}
