using Models.Users.ResultModel;
using Models.Users.TransactionsModel;

namespace Contracts.TransactionsContracts;

public interface ITransactionService
{
    Task<Result> FindUserByCardName(long cardId);
    Task<Result> GetMoney(long cardId, long amount);
    Task<Result> DepositMoney(long cardId, long amount);
    Task<IEnumerable<Transaction>> GetAllTransaction(long cardId);
}