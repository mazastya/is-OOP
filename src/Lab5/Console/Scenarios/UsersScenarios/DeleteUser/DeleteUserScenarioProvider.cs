using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.AddUser;
using Contracts.UsersContract;
using Models.CurrentStates;
using Models.Users;
using Models.UsersModel;

namespace Console.Scenarios.UsersScenarios.DeleteUser;

public class DeleteUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly CurrentState _currentState;

    public DeleteUserScenarioProvider(
        IUserService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentState.User is not null && _currentState.UserRole == UserRole.Admin)
        {
            scenario = new DeleteUserScenario(_service, _currentState);
            return true;
        }

        scenario = null;
        return false;
    }
}