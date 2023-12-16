using Models.CardModel;
using Models.CurrentStates;
using Models.Users.ResultModel;

namespace Contracts.CardsContracts;

public interface ICardService
{
    Task<Result> LoginCard(string cardName, string password);

    Task<Result> CreateCard(string cardName, string password, long userId);
    Task<Result> DeleteCard(string cardName, string password, long userId);
    Task<IEnumerable<Card>> GetAllCard(long userId);
}