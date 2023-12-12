namespace Models.CardModel;

public record Card(long Id, string CardName, long OwnerId, string Password, long Bill);