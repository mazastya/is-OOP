using Models.Users;

namespace Models.CurrentStates;

public interface ICurrentState
{
    UserRole UserRole { get; }
}