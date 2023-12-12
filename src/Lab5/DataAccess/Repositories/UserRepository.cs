using System.Diagnostics.CodeAnalysis;
using Abstraction.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.Users;
using Models.UsersModel;
using Npgsql;

namespace DataAccess.Repositories;

[SuppressMessage("", "CA2007", Justification = "Methods")]
[SuppressMessage("", "CA1849", Justification = "Methods")]
public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByUsername(string username, string password)
    {
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        const string sql = """
                           select user_id, user_name, user_role, user_password
                           from users
                           where user_name = :username AND user_password = :password;
                           """;

        // Task<NpgsqlConnection> task = _connectionProvider
        //     .GetConnectionAsync(default).AsTask();
        // NpgsqlConnection connection = task
        //     .GetAwaiter()
        //     .GetResult();
        await using var command = new NpgsqlCommand();
        command.CommandText = sql;
        command.Connection = connection;

        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("customer", UserRole.Customer);
        command.Parameters.AddWithValue("password", password);
        command.Prepare();

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync(CancellationToken.None);

        if (await reader.ReadAsync() is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            UserRole: reader.GetFieldValue<UserRole>(2),
            Password: reader.GetString(3));
    }

    public async Task<User?> AddNewUser(string username, string password)
    {
        if (password == null) throw new ArgumentNullException(nameof(password));

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        string sql =
            "INSERT INTO users(user_name, user_role, user_password) VALUES (@username, @customer, @password)";

        await using var command = new NpgsqlCommand();
        command.CommandText = sql;
        command.Connection = connection;

        command.Parameters.AddWithValue("username", username);
        command.Parameters.AddWithValue("customer", UserRole.Customer);
        command.Parameters.AddWithValue("password", password);
        command.Prepare();

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (await reader.ReadAsync() is false)
            return null;

        return new User(
            Id: reader.GetInt64(0),
            Username: reader.GetString(1),
            UserRole: reader.GetFieldValue<UserRole>(2),
            Password: reader.GetString(3));
    }

    public async Task<bool> DeleteUser(string username, string password)
    {
        if (password == null) throw new ArgumentNullException(nameof(password));

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        string sql = "DELETE FROM users WHERE user_name = @username";

        await using var command = new NpgsqlCommand();
        command.CommandText = sql;
        command.Connection = connection;

        command.Parameters.AddWithValue("username", username);
        command.Prepare();

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (await reader.ReadAsync() is false)
            return false;

        return true;
    }
}