using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.UsersScenarios.AddUser;
using Contracts.CardsContracts;
using Contracts.UsersContract;
using Models.CurrentStates;

namespace Console.Scenarios.CardScenarios.AddCard;

public class AddCardScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public AddCardScenarioProvider(
        ICardService service,
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
            scenario = new AddCardScenario(_service, _currentState);
            return true;
        }

        scenario = null;
        return false;
    }
}