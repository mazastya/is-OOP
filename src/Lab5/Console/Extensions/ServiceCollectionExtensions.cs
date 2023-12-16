using Console.Scenarios;
using Console.Scenarios.AddUser;
using Console.Scenarios.CardScenarios;
using Console.Scenarios.CardScenarios.AddCard;
using Console.Scenarios.Login;
using Console.Scenarios.TransactionScenarios.GetMoney;
using Console.Scenarios.TransactionScenarios.ViewHistoryTransaction;
using Console.Scenarios.UsersScenarios.DeleteUser;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, AddUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DeleteUserScenarioProvider>();

        collection.AddScoped<IScenarioProvider, LoginCardScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddCardScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DeleteCardScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewInformationScenarioProvider>();

        collection.AddScoped<IScenarioProvider, GetMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewHistoryTransactionScenarioProvider>();

        // collection.AddScoped<IScenarioProvider, AddShopScenarioProvider>();
        return collection;
    }
}