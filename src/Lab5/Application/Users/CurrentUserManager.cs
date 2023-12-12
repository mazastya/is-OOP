using System.Reflection;
using Contracts.UsersContract;
using Models.Users;
using Models.UsersModel;

[assembly: AssemblyVersion("0.0.0.1")]

namespace Application.Users;

public sealed class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}