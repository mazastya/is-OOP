using System.Diagnostics.CodeAnalysis;
using Contracts.UsersContract;
using Models.CurrentStates;
using Models.Users;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.UsersScenarios.AddUser;
[SuppressMessage("", "CA2007", Justification = "Methods")]

public class AddUserScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurrentState _currentState;
    public AddUserScenario(
        IUserService userService,
        CurrentState currentState)
    {
        _userService = userService;
        _currentState = currentState;
    }

    public string Name => "Add user";

    public Task<Task> Run()
    {
        string username = AnsiConsole.Prompt(new TextPrompt<string>("Enter your username"));
        string passwordLogin = AnsiConsole.Prompt(new TextPrompt<string>("Enter password for '" + username + "': "));

        Result result = IScenario.GetFromAsync(_userService.Login(username, passwordLogin));

        string message;
        if (_currentState.User != null && _currentState.UserRole == UserRole.Admin)
        {
            switch (result.ResultType)
            {
                case ResultType.Success:
                    message = "User already exist";
                    break;
                case ResultType.Failure:
                    string password =
                        AnsiConsole.Prompt(new TextPrompt<string>("Confirm your password for '" + username + "': "));
                    IScenario.GetFromAsync(_userService.AddNewUser(username, password));
                    message = "User successfully registered!";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            message = "You have no rights to create a user";
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}