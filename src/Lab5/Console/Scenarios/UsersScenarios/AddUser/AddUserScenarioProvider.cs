using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.Login;
using Console.Scenarios.UsersScenarios.AddUser;
using Contracts.UsersContract;
using Models.CurrentStates;
using Models.Users;

namespace Console.Scenarios.AddUser;

public class AddUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly CurrentState _currentState;

    public AddUserScenarioProvider(
        IUserService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentState.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AddUserScenario(_service, _currentState);
        return true;
    }
}