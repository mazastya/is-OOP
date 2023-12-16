using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.CardScenarios.AddCard;
using Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;
using Contracts.CardsContracts;
using Models.CurrentStates;

namespace Console.Scenarios.CardScenarios;

public class LoginCardScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public LoginCardScenarioProvider(
        ICardService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentState.User is not null)
        {
            scenario = new LoginCardScenario(_service, _currentState);
            return true;
        }

        scenario = null;
        return false;
    }
}