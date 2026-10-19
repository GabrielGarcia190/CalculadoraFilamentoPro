using CalculadoraFilamentoPro.Domain.Configurations.Enums;

namespace CalculadoraFilamentoPro.Domain.Configurations.Results;

public class ConfigurationResult
{
    public EDatabaseProvider Provider { get; set; }
    public string ConnectionString { get; set; }
}