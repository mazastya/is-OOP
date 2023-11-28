namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.PartsOfBlocks;

public interface IPartOfBlock
{
    public string Name { get; set; }
    public IPartOfBlock Clone();
}