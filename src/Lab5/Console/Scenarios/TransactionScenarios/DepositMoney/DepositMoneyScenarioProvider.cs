using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.TransactionScenarios.DepositMoney;
using Contracts.TransactionsContracts;
using Models.CurrentStates;
using Models.Users;

namespace Console.Scenarios.TransactionScenarios.GetMoney;

public class DepositMoneyScenarioProvider : IScenarioProvider
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public DepositMoneyScenarioProvider(
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
            scenario = new DepositMoneyScenario(_transactionService, _currentState);
            return true;
        }

        scenario = null;
        return false;
    }
}