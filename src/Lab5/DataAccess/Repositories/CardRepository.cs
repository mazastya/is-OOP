using System.Data;
using System.Diagnostics.CodeAnalysis;
using Abstraction.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models.CardModel;
using Models.CurrentStates;
using Models.Users;
using Models.UsersModel;
using Npgsql;

namespace DataAccess.Repositories;

[SuppressMessage("", "CA2007", Justification = "Methods")]
[SuppressMessage("", "CA2100", Justification = "Methods")]
public class CardRepository : ICardRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public CardRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Card?> FindUserByCardName(string cardName, string password, long userId)
    {
        if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);
        string sql = """
                     select card_id, card_name, owner_card_id, card_password, card_bill
                     from cards
                     where card_name = :cardName AND card_password = :password;
                     """;

        await using var command = new NpgsqlCommand();
        command.CommandText = sql;
        command.Connection = connection;

        command.Parameters.AddWithValue("cardName", NpgsqlTypes.NpgsqlDbType.Text, cardName);
        command.Parameters.AddWithValue("password", NpgsqlTypes.NpgsqlDbType.Text, password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync(CancellationToken.None);

        if (await reader.ReadAsync() is false)
            return null;

        return new Card(
            Id: reader.GetInt64(0),
            CardName: reader.GetString(1),
            OwnerId: reader.GetInt32(2),
            Password: reader.GetString(3),
            Bill: reader.GetInt64(4));
    }

    public async Task<Card?> AddNewCard(string cardName, string password, long userId)
    {
        if (password == null) throw new ArgumentNullException(nameof(password));

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        string sql =
            "INSERT INTO cards(card_name, owner_card_id, card_password, card_bill) VALUES (@cardName, @userId, @password, @card_bill)";

        await using var command = new NpgsqlCommand();
        command.CommandText = sql;
        command.Connection = connection;

        command.Parameters.AddWithValue("cardName", cardName);
        command.Parameters.AddWithValue("userId", userId);
        command.Parameters.AddWithValue("password", password);
        command.Parameters.AddWithValue("card_bill", 0);
        command.Prepare();

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
            return null;

        return new Card(
            Id: reader.GetInt64(0),
            CardName: reader.GetString(1),
            OwnerId: reader.GetInt32(2),
            Password: reader.GetString(3),
            Bill: reader.GetInt64(4));
    }

    public async Task<bool> DeleteCard(string cardName, string password, long userId)
    {
        if (password == null) throw new ArgumentNullException(nameof(password));

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        string sql = "DELETE FROM cards WHERE card_name = @cardName";

        await using var command = new NpgsqlCommand();
        command.CommandText = sql;
        command.Connection = connection;

        command.Parameters.AddWithValue("cardName", cardName);
        command.Prepare();

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() is false)
            return false;

        return true;
    }

    public async Task<IEnumerable<Card>> GetAllCard(long userId)
    {
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        string sql =
            "SELECT card_id, card_name, owner_card_id, card_password, card_bill FROM cards WHERE owner_card_id = @userId";
        await using var command = new NpgsqlCommand();
        command.CommandText = sql;
        command.Connection = connection;

        command.Parameters.AddWithValue("userId", userId);
        command.Prepare();

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        IList<Card> cards = new List<Card>();
        while (await reader.ReadAsync())
        {
            cards.Add(new Card(
                Id: reader.GetInt64(0),
                CardName: reader.GetString(1),
                OwnerId: reader.GetInt32(2),
                Password: reader.GetString(3),
                Bill: reader.GetInt64(4)));
        }

        return cards;
    }
}