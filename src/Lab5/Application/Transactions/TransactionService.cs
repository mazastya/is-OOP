using System.Diagnostics.CodeAnalysis;
using Abstraction.Repositories;
using Contracts.TransactionsContracts;
using Models.CurrentStates;
using Models.Users.ResultModel;
using Models.Users.TransactionsModel;

namespace Application.Transactions;

[SuppressMessage("", "CA2007", Justification = "Repo")]
public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly CurrentState _currentState;

    public TransactionService(ITransactionRepository repository, CurrentState currentState)
    {
        _repository = repository;
        _currentState = currentState;
    }

    public async Task<Result> FindUserByCardName(long cardId)
    {
        Task<Transaction?> transactionTask = _repository.FindUserByCardName(cardId);
        Transaction? transaction = await transactionTask;

        if (transaction is not null)
        {
            return new Result(ResultType.Success, "Success find transaction");
        }

        return new Result(ResultType.Failure, "Transaction not found");
    }

    public async Task<Result> GetMoney(long cardId, long amount)
    {
        Task<long> balance = GetAccountBalance();
        if (await balance < amount)
        {
            return new Result(ResultType.Failure, "not enough money to get");
        }

        await _repository.UpdateBalance(await balance - amount, _currentState);
        return new Result(ResultType.Success, string.Empty);
    }

    public async Task<Result> DepositMoney(long cardId, long amount)
    {
        Task<long> balance = GetAccountBalance();
        await _repository.UpdateBalance((await balance) + amount, _currentState);
        return new Result(ResultType.Success, string.Empty);
    }

    public async Task<long> GetAccountBalance()
    {
        return await _repository.GetCardBalance(_currentState);
    }

    public async Task<IEnumerable<Transaction>> GetAllTransaction(long cardId)
    {
        return await _repository.GetAllTransaction(cardId);
    }
}