using CalculadoraFilamentoPro.Domain.Configurations.Entities;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using System.Text.Json;

namespace CalculadoraFilamentoPro.Infra.Configuration.Repositories;

public class ConfigurationRepository : IConfigurationRepository
{
    private readonly string _configurationFile;

    public ApplicationConfiguration Configuration { get; private set; } = new();

    public ConfigurationRepository()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        var directory = Path.Combine(appData, "CalculadoraFilamentoPro");

        _configurationFile = Path.Combine(directory, "configuration.json");
    }

    public async Task<ApplicationConfiguration> GetConfigurationAsync()
    {
        if (!File.Exists(_configurationFile))
            return new ApplicationConfiguration();

        try
        {
            var json = await File.ReadAllTextAsync(_configurationFile);

            var configuration = JsonSerializer.Deserialize<ApplicationConfiguration>(json, JsonOptions());

            return configuration ?? new ApplicationConfiguration();
        }
        catch
        {
            return new ApplicationConfiguration();
        }
    }

    public async Task SaveConfigurationAsync(ApplicationConfiguration configuration)
    {
        var directory = Path.GetDirectoryName(_configurationFile)!;

        Directory.CreateDirectory(directory);

        var json = JsonSerializer.Serialize(configuration, JsonOptions());

        await File.WriteAllTextAsync(_configurationFile, json);
    }

    private static JsonSerializerOptions JsonOptions()
    {
        return new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public void Load()
    {
        if (!File.Exists(_configurationFile))
        {
            Configuration = new ApplicationConfiguration();
            return;
        }

        var json =  File.ReadAllText(_configurationFile);

        Configuration = JsonSerializer.Deserialize<ApplicationConfiguration>(json) ?? new ApplicationConfiguration();
    }
}