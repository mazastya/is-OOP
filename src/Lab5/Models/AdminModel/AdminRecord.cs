namespace Models.Users.AdminModel;

public record AdminRecord(long Id, string Username, UserRole Role, string Password);