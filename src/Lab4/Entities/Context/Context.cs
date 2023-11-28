using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Models.TraversalDirectory;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Context;

public class Context : IContext
{
    public Context(
        string path,
        IFileSystem fileSystem,
        ITree treeTraversal,
        IStringBuildForTree stringBuildForTreeForTree)
    {
        Path = path;
        FileSystem = fileSystem;
        TreeTraversal = treeTraversal;
        StringBuildForTreeForTree = stringBuildForTreeForTree;
    }

    public string Path { get; set; }
    public IFileSystem FileSystem { get; set; }
    public ITree TreeTraversal { get; set; }
    public IStringBuildForTree StringBuildForTreeForTree { get; set; }

    public bool ConnectToPath(string path, string mode)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(mode);

        FileSystem = mode.ToUpper(System.Globalization.CultureInfo.CurrentCulture) switch
        {
            "local" => new FileSystem.FileSystem(),
            _ => throw new ArgumentException("Not found needed mode", mode),
        };

        return FileSystem.Connect(path, mode);
    }

    public void ChangeCurrentPath(string path)
    {
    }

    public IContext Clone()
    {
        return new Context(Path, FileSystem, TreeTraversal, StringBuildForTreeForTree)
        {
            Path = Path,
        };
    }
}