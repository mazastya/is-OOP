using System.Diagnostics.CodeAnalysis;
using Contracts.UsersContract;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.UsersScenarios.Login;

[SuppressMessage("", "CA2007", Justification = "Methods")]
public class LoginScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login";

    public Task<Task> Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username");
        string passwordLogin = AnsiConsole.Ask<string>("Enter password for '" + username + "': ");

        Result result = IScenario.GetFromAsync(_userService.Login(username, passwordLogin));

        string message;
        switch (result.ResultType)
        {
            case ResultType.Success:
                message = "Successful login!";
                break;
            case ResultType.Failure:
                AnsiConsole.WriteLine("User not found");
                bool wanna = AnsiConsole.Confirm("Want to create a new user with username: '" + username + "' ?");
                if (wanna)
                {
                    string password =
                        AnsiConsole.Prompt(new TextPrompt<string>("Confirm your password for '" + username + "': "));
                    IScenario.GetFromAsync(_userService.AddNewUser(username, password));
                    message = "User successfully registered!";
                }
                else
                {
                    message = "User has not been created";
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