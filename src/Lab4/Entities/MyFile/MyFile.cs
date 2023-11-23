namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.MyFile;

public class MyFile(string nameFile, string? pathFile)
{
    public string NameFile { get; set; } = nameFile;
    public string? PathFile { get; set; } = pathFile;
}