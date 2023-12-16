using System.Diagnostics.CodeAnalysis;
using Contracts.CardsContracts;
using Models.CardModel;
using Models.CurrentStates;
using Models.Users.ResultModel;
using Spectre.Console;

namespace Console.Scenarios.CardScenarios;

[SuppressMessage("", "CA1305", Justification = "Methods")]
[SuppressMessage("", "SA1117", Justification = "Methods")]

public class ViewInformationScenario : IScenario
{
    private readonly ICardService _cardService;
    private readonly CurrentState _currentState;

    public ViewInformationScenario(
        ICardService service,
        CurrentState currentState)
    {
        _cardService = service;
        _currentState = currentState;
    }

    public string Name => "View card information";

    public async Task<Task> Run()
    {
        if (_currentState.User != null)
        {
            Task<IEnumerable<Card>> cardsTask = _cardService.GetAllCard(_currentState.User.Id);
            IEnumerable<Card> cards = await cardsTask.ConfigureAwait(false);

            SelectionPrompt<Card> selector = new SelectionPrompt<Card>()
                .Title("Select card:")
                .AddChoices(cards)
                .UseConverter(x => x.CardName);

            Card card = AnsiConsole.Prompt(selector);

            AnsiConsole.WriteLine($"You selected {card.CardName}");

            if (selector.Title != null)
            {
                Table spectre = new Table()
                    .Title("Card '" + card.CardName + "' ")
                    .AddColumn(new TableColumn("Card name").Centered())
                    .AddColumn(new TableColumn("Owner name").Centered())
                    .AddColumn(new TableColumn("Card balance").Centered())
                    .AddRow(card.CardName, Convert.ToString(_currentState.User.Username),
                        "[green]" + Convert.ToString(card.Bill) + "[/]");

                AnsiConsole.Write(spectre);
            }
        }

        System.Console.ReadKey();
        return Task.FromResult(Task.CompletedTask);
    }
}