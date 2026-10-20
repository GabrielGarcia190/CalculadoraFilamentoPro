using CalculadoraFilamentoPro.App.Interfaces.Configurations;
using CalculadoraFilamentoPro.App.User.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Pages;

public partial class StartUp
{
    [Inject]
    IConfigurationService ConfigurationService { get; set; } = default!;

    [Inject]
    IUserService UserService { get; set; } = default!;

    [Inject]
    NavigationManager Navigation { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {

        if (!await ConfigurationService.DatabaseConfiguredAsync())
        {
            Navigation.NavigateTo("/database-setup", true);
            return;
        }

        if (await UserService.IsUserAuthenticated())
        {
            Navigation.NavigateTo("/sign-up", true);
            return;
        }

        Navigation.NavigateTo("/login", true);
    }
}