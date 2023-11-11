using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

public class ViewFile
{
    private readonly MyFile _myFile;

    public ViewFile(MyFile myFile)
    {
        _myFile = myFile;
    }

    public static string Writes(MyFile myFile)
    {
        return File.ReadAllText(myFile.PathFile);
    }
}