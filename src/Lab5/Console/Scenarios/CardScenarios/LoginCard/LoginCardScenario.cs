using System.Diagnostics.CodeAnalysis;
using Contracts.CardsContracts;
using Contracts.UsersContract;
using Models.CurrentStates;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.CardScenarios;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class LoginCardScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;
    public LoginCardScenario(
        ICardService cardService,
        CurrentState currentState)
    {
        _cardService = cardService;
        _currentState = currentState;
    }

    public string Name => "Login card account with card name";

    public Task<Task> Run()
    {
        string cardName = AnsiConsole.Ask<string>("Enter your card name");
        string passwordLogin = AnsiConsole.Ask<string>("Enter password for '" + cardName + "': ");

        Result result = IScenario.GetFromAsync(_cardService.LoginCard(cardName, passwordLogin));

        string message;
        switch (result.ResultType)
        {
            case ResultType.Success:
                message = "Successful login!";
                break;
            case ResultType.Failure:
                AnsiConsole.WriteLine("Card not found");
                bool wanna = AnsiConsole.Confirm("Want to create a new card with card name: '" + cardName + "' ?");
                if (wanna)
                {
                    string password =
                        AnsiConsole.Prompt(new TextPrompt<string>("Confirm your password for '" + cardName + "': "));
                    if (_currentState.User != null)
                        IScenario.GetFromAsync(_cardService.CreateCard(cardName, password, _currentState.User.Id));
                    message = "Card successfully registered!";
                }
                else
                {
                    message = "Card has not been created";
                }

                break;
            case ResultType.None:
            default:
                throw new ArgumentOutOfRangeException();
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}