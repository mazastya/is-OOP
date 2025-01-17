using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilePart;

public class FilePart : IFilePart
{
    public FilePart(
        string name)
    {
        Name = name;

        int startNameIndex = name.LastIndexOf('.');
        if (startNameIndex == -1)
        {
            startNameIndex = 0;
        }

        Extension = name[startNameIndex..];
    }

    public string Name { get; set; }
    public string Extension { get; }

    public IPartOfBlock Clone()
    {
        return new FilePart(Name);
    }
}