using Models.Users;

namespace Models.UsersModel;

public record User(long Id, string Username, UserRole UserRole, string Password);