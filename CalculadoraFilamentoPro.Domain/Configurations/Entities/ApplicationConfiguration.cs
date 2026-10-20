using CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

namespace CalculadoraFilamentoPro.Domain.Configurations.Entities;

public class ApplicationConfiguration
{
    public DataBaseConnection? Database { get; private set; }

    public Guid? LastUserId { get; private set; }

    public bool RememberUser { get; private set; }

    public ApplicationConfiguration() { }

    public void ConfigureDatabase(DataBaseConnection database)
        => Database = database;

    public void Login(Guid userId, bool rememberUser)
    {
        LastUserId = userId;
        RememberUser = rememberUser;
    }

    public void Logout()
    {
        LastUserId = null;
        RememberUser = false;
    }
}