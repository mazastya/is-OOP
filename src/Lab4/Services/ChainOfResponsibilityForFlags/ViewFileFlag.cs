using Itmo.ObjectOrientedProgramming.Lab4.Services.IterationsWithFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.ChainOfResponsibilityForFlags;

public class ViewFileFlag : HandlerBase
{
    protected override bool CanHandle(string[] request)
    {
        if (request[0] == "file" && request[1] == "show")
        {
            if (request[3] == "-m" && request[4] == "console")
            {
                return true;
            }
        }
        else
        {
            return false;
        }

        return false;
    }

    protected override string Handle(string[] request)
    {
        var viewFile = new ViewFile(request[2]);
        viewFile.Execute(request[2]);
        return "viewed file complete";
    }
}