using System.Diagnostics.CodeAnalysis;
using Contracts.TransactionsContracts;
using Models.CurrentStates;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.TransactionScenarios.GetMoney;

[SuppressMessage("", "CA1305", Justification = "Methods")]
[SuppressMessage("", "CA2007", Justification = "Methods")]
[SuppressMessage("", "SA1117", Justification = "Methods")]
public class GetMoneyScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public GetMoneyScenario(ITransactionService transactionService, CurrentState currentState)
    {
        _transactionService = transactionService;
        _currentState = currentState;
    }

    public string Name => "Get money";

    public async Task<Task> Run()
    {
        long amount = AnsiConsole.Ask<long>("Enter the amount of money you wish to receive: ");
        if (_currentState.User != null)
        {
            Task<Result> resultTask = _transactionService.GetMoney(_currentState.User.Id, amount);
            Result result = await resultTask;

            string message = result.ResultType switch
            {
                ResultType.Success => amount + " has been withdrawn from the account",
                ResultType.Failure => "Failed " + result.Message,
                _ => throw new ArgumentOutOfRangeException(nameof(result)),
            };

            AnsiConsole.WriteLine(message);
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}