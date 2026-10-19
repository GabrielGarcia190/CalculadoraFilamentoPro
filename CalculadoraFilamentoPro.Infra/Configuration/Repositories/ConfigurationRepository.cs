using System.Text.Json;
using System.Text.Json.Serialization;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Configurations.Results;
using CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

namespace CalculadoraFilamentoPro.Infra.Configuration.Repositories;

public class ConfigurationRepository : IConfigurationRepository
{
    private readonly string _configurationFile;

    public ConfigurationRepository()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        _configurationFile = Path.Combine(appData, "CalculadoraFilamentoPro", "database.json");
    }

    public async Task SaveConnectionStringAsync(DataBaseConnection connection)
    {
        var directory = Path.GetDirectoryName(_configurationFile);

        if (!string.IsNullOrWhiteSpace(directory))
            Directory.CreateDirectory(directory);

        var configuration = new ConfigurationResult
        {
            Provider = connection.Provider,
            ConnectionString = connection.ConnectionString
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        options.Converters.Add(new JsonStringEnumConverter());

        var json = JsonSerializer.Serialize(configuration, options);

        await File.WriteAllTextAsync(_configurationFile, json);
    }

    public async Task<DataBaseConnection?> GetConnectionStringAsync()
    {
        if (!File.Exists(_configurationFile))
            return null;

        var options = new JsonSerializerOptions();

        options.Converters.Add(new JsonStringEnumConverter());

        var json = await File.ReadAllTextAsync(_configurationFile);

        var configuration = JsonSerializer.Deserialize<ConfigurationResult>(json, options);

        if (configuration == null) return null;

        if (string.IsNullOrWhiteSpace(configuration.ConnectionString)) return null;

        return new DataBaseConnection(configuration.Provider, configuration.ConnectionString);
    }
}