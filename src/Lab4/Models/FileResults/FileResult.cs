namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public class FileResult
{
    public FileResult(FileResultType status)
    {
        Status = status;
    }

    public FileResultType Status { get; set; }
}