using CalculadoraFilamentoPro.Domain.Configurations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraFilamentoPro.Domain.Configurations.ValueObjects;

public sealed class DataBaseConnection
{
    public DataBaseConnection(EDatabaseProvider provider, string connectionString)
    {
        Provider = provider;
        ConnectionString = connectionString;
    }

    public EDatabaseProvider Provider { get; }

    public string ConnectionString { get; }
}
