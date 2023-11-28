using System.Collections.Generic;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;

public interface IFileSystem
{
    bool Connect(string path, string? mode);

    void Disconnect();

    void ChangeDirectory(string path);
    bool IsFolder(string path);

    IEnumerable<string> ListDirectory(string path, int? depth);

    string? FileShow(string path, string mode);
    FileResult FileMove(string sourcePath, string destinationPath);
    FileResult FileCopy(string sourcePath, string destinationPath);
    FileResult FileDelete(string path);
    FileResult FileRename(string path, string newFileName);
}