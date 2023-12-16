using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using Abstraction.Repositories;
using Contracts.UsersContract;
using Models.CurrentStates;
using Models.Users;
using Models.Users.ResultModel;
using Models.UsersModel;

namespace Application.Users;

[SuppressMessage("", "CA2007", Justification = "Repo")]
internal class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentState _currentState;

    public UserService(IUserRepository repository, CurrentState currentState)
    {
        _repository = repository;
        _currentState = currentState;
    }

    public async Task<Result> Login(string username, string password)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        Task<User?> userTask = _repository.FindUserByUsername(username, Convert.ToBase64String(hash));

        User? user = await userTask;

        if (Convert.ToBase64String(hash) == user?.Password)
        {
            _currentState.User = user;
            return new Result(ResultType.Success, "successful login");
        }

        return new Result(ResultType.Failure, "wrong password");
    }

    public async Task<Result> AddNewUser(string username, string password)
    {
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        Task<User?> userTask = _repository.AddNewUser(username, Convert.ToBase64String(hash));
        User? user = await userTask;

        if (user is null)
        {
            return new Result(ResultType.Failure, "user '" + username + "' failed added");
        }

        _currentState.User = user;
        return new Result(ResultType.Success, "user '" + username + "' success added");
    }

    public async Task<Result> DeleteUser(string username, string password)
    {
        Task<bool> userTask = _repository.DeleteUser(username, password);

        bool delete = await userTask;
        if (delete)
        {
            _currentState.User = null;
            return new Result(ResultType.Success, "Success deleted");
        }

        return new Result(ResultType.Failure, "delete is failure");
    }
}