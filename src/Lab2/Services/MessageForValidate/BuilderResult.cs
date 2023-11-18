namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MessageForUser;

public class BuilderResult
{
    public BuilderResultStatusType BuilderResultStatusType { get; set; } = BuilderResultStatusType.Success;
    public string? Message { get; set; }
    public bool ComputerCanBeStarted { get; set; }
}