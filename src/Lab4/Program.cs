using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;
using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var connect = new ConnectFlag();
        var copyFile = new CopyFileFlag();
        var deleteFile = new DeleteFileFlag();
        var moveFile = new MoveFileFlag();
        var renameFile = new RenameFileFlag();
        var showFile = new ShowFileFlag();
        var treeList = new TreeListFlag();

        connect.SetNextHandler(copyFile);
        copyFile.SetNextHandler(deleteFile);
        deleteFile.SetNextHandler(moveFile);
        moveFile.SetNextHandler(renameFile);
        showFile.SetNextHandler(treeList);

        while (true)
        {
            string? input = Console.ReadLine();
            if (input == "exit")
            {
                break;
            }

            if (input is null) continue;
            string[] inputSplit = input.Split(' ');
            connect.HandleRequest(inputSplit);
        }
    }
}