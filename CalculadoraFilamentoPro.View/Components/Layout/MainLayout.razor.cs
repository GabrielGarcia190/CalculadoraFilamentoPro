using CalculadoraFilamentoPro.App.Interfaces.Authentication;
using CalculadoraFilamentoPro.App.Interfaces.Configurations;
using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        public IConfigurationService Config { get; set; } = default!;

        [Inject]
        private IAuthenticationService Authentication { get; set; } = default!;


        protected bool Configurado;
        protected bool Logado;


        protected override async Task OnInitializedAsync()
        {
            Configurado = await Config.DatabaseConfiguredAsync();
            Logado = await Authentication.IsAuthenticatedAsync();
        }
    }
}