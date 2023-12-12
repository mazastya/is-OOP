using Models.CurrentStates;
using Models.Users.ResultModel;
using Models.Users.TransactionsModel;

namespace Abstraction.Repositories;

public interface ITransactionRepository
{
    Task<Transaction?> FindUserByCardName(long cardId);

    Task<long> GetCardBalance(CurrentState currentState);
    Task UpdateBalance(long amount, CurrentState currentState);
    Task<IEnumerable<Transaction>> GetAllTransaction(long cardId);
}