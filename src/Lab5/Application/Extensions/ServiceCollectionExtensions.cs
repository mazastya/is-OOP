using Application.Cards;
using Application.Transactions;
using Application.Users;
using Contracts.CardsContracts;
using Contracts.TransactionsContracts;
using Contracts.UsersContract;
using Microsoft.Extensions.DependencyInjection;
using Models.CurrentStates;

// using Application.Contracts.Products;
// using Application.Contracts.Shops;
// using Application.Contracts.Users;
// using Application.Products;
// using Application.Shops;
// using Application.Users;
namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<ICardService, CardService>();
        collection.AddScoped<ITransactionService, TransactionService>();

        // collection.AddScoped<IShopService, ShopService>();
        // collection.AddScoped<IProductService, ProductService>();
        collection.AddSingleton<CurrentState>();
        collection.AddSingleton<ICurrentState>(
            p => p.GetRequiredService<CurrentState>());
        return collection;
    }
}