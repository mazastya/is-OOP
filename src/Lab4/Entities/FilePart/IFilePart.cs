using Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FilePart;

public interface IFilePart : IPartOfBlock
{
    public string Extension { get; }
}