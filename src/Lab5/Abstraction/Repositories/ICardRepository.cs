using Models.CardModel;
using Models.CurrentStates;

namespace Abstraction.Repositories;

public interface ICardRepository
{
    Task<Card?> FindUserByCardName(string cardName, string password, long userId);

    Task<Card?> AddNewCard(string cardName, string password, long userId);
    Task<bool> DeleteCard(string cardName, string password, long userId);
    Task<IEnumerable<Card>> GetAllCard(long userId);
}