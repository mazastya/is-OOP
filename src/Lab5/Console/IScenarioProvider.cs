using System.Diagnostics.CodeAnalysis;
using Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;

namespace Console.Scenarios;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}