using System.Diagnostics.CodeAnalysis;
using Contracts.TransactionsContracts;
using Models.CardModel;
using Models.CurrentStates;
using Models.Users.TransactionsModel;
using Spectre.Console;

namespace Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;

[SuppressMessage("", "CA1305", Justification = "Methods")]
[SuppressMessage("", "SA1117", Justification = "Methods")]
public class ViewHistoryTransactionScenario : IScenario
{
    private readonly ITransactionService _transactionService;
    private readonly CurrentState _currentState;

    public ViewHistoryTransactionScenario(
        CurrentState currentState,
        ITransactionService transactionService)
    {
        _currentState = currentState;
        _transactionService = transactionService;
    }

    public string Name => "View history transactions";

    public async Task<Task> Run()
    {
        if (_currentState.Card != null)
        {
            Task<IEnumerable<Transaction>> transactionsTask = _transactionService.GetAllTransaction(_currentState.Card.Id);
            IEnumerable<Transaction> transactions = await transactionsTask.ConfigureAwait(false);

            SelectionPrompt<Transaction> selector = new SelectionPrompt<Transaction>()
                .Title("Select date transaction:")
                .AddChoices(transactions)
                .UseConverter(x => Convert.ToString(x.TransactionDate));

            Transaction transaction = AnsiConsole.Prompt(selector);

            AnsiConsole.WriteLine($"You selected {transaction.TransactionDate}");

            if (selector.Title != null)
            {
                Table spectre = new Table()
                    .Title("Transaction '" + transaction.TransactionDate + "' ")
                    .AddColumn(new TableColumn("Card ID").Centered())
                    .AddColumn(new TableColumn("Transaction act").Centered())
                    .AddColumn(new TableColumn("Transaction date").Centered())
                    .AddRow(Convert.ToString(transaction.CardId), transaction.TransactionName,
                        "[turquoise4]" + transaction.TransactionDate + "[/]");

                AnsiConsole.Write(spectre);
            }
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}