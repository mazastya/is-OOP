using System.Diagnostics.CodeAnalysis;
using Contracts.UsersContract;
using Models.CurrentStates;
using Models.Users;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.UsersScenarios.DeleteUser;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class DeleteUserScenario : IScenario
{
    private readonly IUserService _userService;
    private readonly CurrentState _currentState;

    public DeleteUserScenario(IUserService userService, CurrentState currentState)
    {
        _userService = userService;
        _currentState = currentState;
    }

    public string Name => "Delete user";

    public Task<Task> Run()
    {
        string username = AnsiConsole.Prompt(new TextPrompt<string>("Enter the username you want to delete: "));
        string passwordLogin = AnsiConsole.Ask<string>("Enter password for '" + username + "': ");

        Result result = IScenario.GetFromAsync(_userService.Login(username, passwordLogin));

        string message;
        if (_currentState.UserRole == UserRole.Admin)
        {
            switch (result.ResultType)
            {
                case ResultType.Failure:
                    message = "User already not exist";
                    break;
                case ResultType.Success:
                    bool wanna = AnsiConsole.Confirm("Are you sure you want to delete user '" + username + "'?");
                    if (wanna)
                    {
                        string password =
                            AnsiConsole.Prompt(
                                new TextPrompt<string>("Confirm your password for '" + username + "': "));
                        IScenario.GetFromAsync(_userService.DeleteUser(username, password));
                        message = "Card successfully deleted!";
                    }
                    else
                    {
                        message = "User '" + username + "' has not been deleted";
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            message = "You have no rights to create a card";
        }

        AnsiConsole.WriteLine(message);
        System.Console.ReadKey();
        return (Task<Task>)Task.CompletedTask;
    }
}