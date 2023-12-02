using Castle.Core.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public class Display : IDisplay
{
    private readonly ILogger _logger;
    private readonly IDisplayDriver _driver;

    public Display(ILogger logger, IDisplayDriver driver)
    {
        _logger = logger;
        _driver = driver;
    }

    public void PrintColorText(string textBody)
    {
        _driver.ClearOutput();
        _driver.SetTextBody(textBody);
        _logger.CreateChildLogger(_driver.GetColorText());
    }
}