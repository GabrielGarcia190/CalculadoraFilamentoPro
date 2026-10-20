using CalculadoraFilamentoPro.Domain.Configurations.Enums;
using CalculadoraFilamentoPro.Domain.Data.ValueObjects;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

public sealed class DataBaseConnection
{
    [JsonConstructor]
    public DataBaseConnection(EDatabaseProvider provider, string connectionString)
    {
        Provider = provider;
        ConnectionString = connectionString;
    }

    public EDatabaseProvider Provider { get; private set; }

    [JsonIgnore]
    public ConnectionString Connection { get; private set; }

    [JsonPropertyName("connectionString")]
    public string ConnectionString
    {
        get => Connection.ToString();
        private set => Connection = new ConnectionString(Provider, value);
    }
}