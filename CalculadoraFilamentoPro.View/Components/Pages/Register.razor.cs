namespace CalculadoraFilamentoPro.Components.Pages
{
    public partial class Register
    {
        private string Name = string.Empty;

        private string Password = string.Empty;

        private string? Error;

        private Task CreateUser()
        {
            // Implementar

            return Task.CompletedTask;
        }

        private void Back()
        {
            // NavigationManager.NavigateTo("/login");
        }
    }
}
