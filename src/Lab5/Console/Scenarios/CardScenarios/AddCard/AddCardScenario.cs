using Contracts.CardsContracts;
using Contracts.UsersContract;
using Models.CurrentStates;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.CardScenarios.AddCard;

public class AddCardScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;
    public AddCardScenario(
        ICardService cardService,
        CurrentState currentState)
    {
        _cardService = cardService;
        _currentState = currentState;
    }

    public string Name => "Add new card";

    public async Task<Task> Run()
    {
        string cardName = AnsiConsole.Prompt(new TextPrompt<string>("Enter your card name"));
        string passwordCard = AnsiConsole.Prompt(new TextPrompt<string>("Enter password for '" + cardName + "': "));

        Task<Result> result = _cardService.LoginCard(cardName, passwordCard);
        Result res = await result.ConfigureAwait(false);

        string message;
        switch (res.ResultType)
        {
            case ResultType.Success:
                message = "Card already exist";
                break;
            case ResultType.Failure:
                string password =
                    AnsiConsole.Prompt(new TextPrompt<string>("Confirm your password for '" + cardName + "': "));
                if (_currentState.User != null)
                    await _cardService.CreateCard(cardName, password, _currentState.User.Id).ConfigureAwait(false);
                message = "User successfully registered!";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}