using Models.CardModel;
using Models.Users;
using Models.UsersModel;

namespace Models.CurrentStates;

public class CurrentState : ICurrentState
{
    public UserRole UserRole { get; set; } = Users.UserRole.None;
    public User? User { get; set; }
    public Card? Card { get; set; }
}