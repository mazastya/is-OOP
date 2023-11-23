namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.MyFile;

public class MyFile
{
    public MyFile(string nameFile, string? pathFile)
    {
        NameFile = nameFile;
        PathFile = pathFile;
    }

    public string NameFile { get; set; }
    public string? PathFile { get; set; }
}