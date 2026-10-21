using CalculadoraFilamentoPro.App.User.Interfaces;
using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Pages
{
    public partial class Register
    {
        [Inject]
        private IUserService UserService { get; set; } = default!;

        [Inject]
        private NavigationManager Navigation { get; set; } = default!;

        private string UserName = string.Empty;

        private string Password = string.Empty;

        private string? Error;

        private async Task CreateUser()
        {
            try
            {
                await UserService.CreateUser(UserName, Password);
                Navigation.NavigateTo("/login");
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        private void Back()
        {
            Navigation.NavigateTo("/login");
        }
    }
}
