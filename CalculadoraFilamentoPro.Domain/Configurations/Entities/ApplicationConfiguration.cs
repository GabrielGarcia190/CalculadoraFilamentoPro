using CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;
using System.Text.Json.Serialization;

namespace CalculadoraFilamentoPro.Domain.Configurations.Entities;

public class ApplicationConfiguration
{
    [JsonInclude]
    public DataBaseConnection? Database { get; private set; }

    [JsonInclude]
    public Guid? LastUserId { get; private set; }

    [JsonInclude]
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

    public void Load(ApplicationConfiguration configuration)
    {
        Database = configuration.Database;
        LastUserId = configuration.LastUserId;
        RememberUser = configuration.RememberUser;
    }
}