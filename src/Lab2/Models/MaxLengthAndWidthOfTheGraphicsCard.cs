namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class MaxLengthAndWidthOfTheGraphicsCard
{
    public MaxLengthAndWidthOfTheGraphicsCard(int maxLength, int maxWidth)
    {
        MaxLength = maxLength;
        MaxWidth = maxWidth;
    }

    public int MaxLength { get; }
    public int MaxWidth { get; }
}