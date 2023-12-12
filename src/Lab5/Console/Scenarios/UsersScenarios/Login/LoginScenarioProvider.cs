using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;
using Console.Scenarios.UsersScenarios.Login;
using Contracts.UsersContract;
using Models.CurrentStates;

namespace Console.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly CurrentState _currentState;

    public LoginScenarioProvider(
        IUserService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentState.User is null)
        {
            scenario = new LoginScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}