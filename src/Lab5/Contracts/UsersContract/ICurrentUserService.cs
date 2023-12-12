using Models.UsersModel;

namespace Contracts.UsersContract;

public interface ICurrentUserService
{
    User? User { get; }
}