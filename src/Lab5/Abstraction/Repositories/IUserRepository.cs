using Models.Users;
using Models.UsersModel;

namespace Abstraction.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByUsername(string username, string password);
    Task<User?> AddNewUser(string username, string password);

    Task<bool> DeleteUser(string username, string password);
}