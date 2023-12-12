using Contracts.CardsContracts;
using Models.CurrentStates;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.CardScenarios;

public class DeleteCardScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;
    public DeleteCardScenario(
        ICardService cardService,
        CurrentState currentState)
    {
        _cardService = cardService;
        _currentState = currentState;
    }

    public string Name => "Delete card";

    public Task<Task> Run()
    {
        string cardName = AnsiConsole.Prompt(new TextPrompt<string>("Enter your card name"));
        string passwordCard = AnsiConsole.Prompt(new TextPrompt<string>("Enter password for '" + cardName + "': "));

        Result result = IScenario.GetFromAsync(_cardService.LoginCard(cardName, passwordCard));

        string message;
        switch (result.ResultType)
        {
            case ResultType.Failure:
                message = "Card already not exist";
                break;
            case ResultType.Success:
                bool wanna = AnsiConsole.Confirm("Are you sure you want to delete the card?");
                if (wanna)
                {
                    string password =
                        AnsiConsole.Prompt(new TextPrompt<string>("Confirm your password for '" + cardName + "': "));
                    if (_currentState.User != null)
                        IScenario.GetFromAsync(_cardService.DeleteCard(cardName, password, _currentState.User.Id));
                    message = "Card successfully deleted!";
                }
                else
                {
                    message = "Card '" + cardName + "' has not been deleted";
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}