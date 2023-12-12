using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.TransactionScenarios.DepositMoney;
using Contracts.TransactionsContracts;
using Models.CurrentStates;

namespace Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;

public class ViewHistoryTransactionScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public ViewHistoryTransactionScenarioProvider(
        ITransactionService transactionService,
        CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentState.Card is not null && _currentState.User is not null)
        {
            scenario = new ViewHistoryTransactionScenario(_currentState, _transactionService);
            return true;
        }

        scenario = null;
        return false;
    }
}