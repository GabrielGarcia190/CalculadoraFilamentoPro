using System;
using System.Threading.Tasks;
using CalculadoraFilamentoPro.App.Interfaces.Configurations;
using CalculadoraFilamentoPro.Domain.Configurations.Enums;
using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Setup
{
    public partial class DatabaseSetup
    {
        private string ConnectionString { get; set; } = string.Empty;
        private EDatabaseProvider SelectedProvider { get; set; } = EDatabaseProvider.PostgreSql;
        private string? StatusMessage { get; set; }

        //[Inject]
        //public IConfigurationService Config { get; set; } = default!;

        private bool CanConfirm => !string.IsNullOrWhiteSpace(ConnectionString) && SelectedProvider != default(EDatabaseProvider);

        void SelectProvider(EDatabaseProvider provider) => SelectedProvider = provider;

        async Task ConfirmAsync()
        {
            //if (!CanConfirm)
            //    return;

            //try
            //{
            //    if (Config != null)
            //    {
            //        await Config.ConfigureDataBase(ConnectionString);
            //    }

            //    StatusMessage = "Configuração aplicada.";
            //}
            //catch (Exception ex)
            //{
            //    StatusMessage = $"Falha: {ex.Message}";
            //}
        }

        void Cancel() => ConnectionString = string.Empty;
    }
}
