using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.CardScenarios.AddCard;
using Contracts.CardsContracts;
using Models.CurrentStates;

namespace Console.Scenarios.CardScenarios;

public class DeleteCardScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public DeleteCardScenarioProvider(
        ICardService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentState.Card is not null)
        {
            scenario = new DeleteCardScenario(_service, _currentState);
            return true;
        }

        scenario = null;
        return false;
    }
}