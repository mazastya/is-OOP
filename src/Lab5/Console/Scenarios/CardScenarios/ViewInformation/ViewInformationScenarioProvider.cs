using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.CardScenarios.AddCard;
using Contracts.CardsContracts;
using Models.CurrentStates;

namespace Console.Scenarios.CardScenarios;

public class ViewInformationScenarioProvider : IScenarioProvider
{
    private readonly ICardService _service;
    private readonly CurrentState _currentState;

    public ViewInformationScenarioProvider(
        ICardService service,
        CurrentState currentState)
    {
        _service = service;
        _currentState = currentState;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentState.User is not null && _currentState.Card is not null)
        {
            scenario = new ViewInformationScenario(_service, _currentState);
            return true;
        }

        scenario = null;
        return false;
    }
}