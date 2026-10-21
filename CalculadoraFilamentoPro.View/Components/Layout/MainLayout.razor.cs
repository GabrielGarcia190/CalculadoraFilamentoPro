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

        [Inject]
        protected NavigationManager Navigation { get; set; } = default!;

        protected bool Configurado;
        protected bool Logado;
        protected bool MenuAberto { get; set; } = true;

        protected void AlternarMenu() => MenuAberto = !MenuAberto;

        protected override async Task OnInitializedAsync()
        {
            Configurado = await Config.DatabaseConfiguredAsync();

            if (!Configurado)
                return;

            Logado = await Authentication.IsAuthenticatedAsync();

            if (!Logado)
                Navigation.NavigateTo("/login");
        }
    }
}