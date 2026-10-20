using CalculadoraFilamentoPro.Domain.Configurations.Enums;
using System.Data.Common;
using System.Text.Json.Serialization;

namespace CalculadoraFilamentoPro.Domain.Data.ValueObjects;

public class ConnectionString
{
    public string Value { get; private set; }

    public ConnectionString(string value)
        => Value = value;

    public ConnectionString(EDatabaseProvider provider, string value)
        => Value = Normalize(provider, value);

    public static implicit operator string(ConnectionString connection)
        => connection.Value;

    public override string ToString()
        => Value;

    private static string Normalize(EDatabaseProvider provider, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Connection String inválida.");

        return provider switch
        {
            EDatabaseProvider.SQLite => NormalizeSqlite(value),
            EDatabaseProvider.PostgreSql => value.Trim(),
            EDatabaseProvider.SqlServer => value.Trim(),
            _ => throw new NotSupportedException($"Banco {provider} não suportado.")
        };
    }

    private static string NormalizeSqlite(string value)
    {
        value = value.Trim();

        if (!value.Contains('='))
        {
            value = GetAbsolutePath(value);

            return $"Data Source={value}";
        }

        var builder = new DbConnectionStringBuilder { ConnectionString = value };

        if (builder.TryGetValue("DataSource", out var dataSource))
        {
            builder.Remove("DataSource");
            builder["Data Source"] = GetAbsolutePath(dataSource!.ToString()!);
        }

        if (builder.TryGetValue("Data Source", out var source))
        {
            builder["Data Source"] = GetAbsolutePath(source!.ToString()!);
        }

        if (!builder.ContainsKey("Data Source"))
            throw new ArgumentException("Connection String SQLite inválida.");

        return builder.ConnectionString;
    }

    private static string GetAbsolutePath(string path)
    {
        path = path.Trim();

        if (Path.IsPathRooted(path))
            return path;

        var directory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "CalculadoraFilamentoPro");

        Directory.CreateDirectory(directory);

        return Path.Combine(directory, path);
    }
}