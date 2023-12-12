using System.Diagnostics.CodeAnalysis;
using Contracts.TransactionsContracts;
using Models.CurrentStates;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.TransactionScenarios.DepositMoney;

[SuppressMessage("", "CA1305", Justification = "Methods")]
[SuppressMessage("", "CA2007", Justification = "Methods")]
[SuppressMessage("", "SA1117", Justification = "Methods")]
public class DepositMoneyScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public DepositMoneyScenario(ITransactionService transactionService, CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public string Name => "Deposit money";

    public Task<Task> Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter the amount of money you wish to deposite: ");
        if (_currentState.User != null)
        {
            Result result = IScenario.GetFromAsync(_transactionService.DepositMoney(_currentState.User.Id, amount));

            switch (result.ResultType)
            {
                case ResultType.Success:
                    AnsiConsole.Markup("[green]" + amount + " added to the account" + "[/]");
                    break;
                case ResultType.Failure:
                    AnsiConsole.WriteLine("Failed " + result.Message);
                    break;
            }
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}