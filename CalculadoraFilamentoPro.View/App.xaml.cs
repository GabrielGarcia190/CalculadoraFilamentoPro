using CalculadoraFilamentoPro.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraFilamentoPro.View
{
    public partial class App : IApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var services = IPlatformApplication.Current?.Services;

            if (services is not null)
                Task.Run(() => ExecuteDatabaseMigrationAsync(services))
                    .GetAwaiter()
                    .GetResult();

            return new Window(new MainPage()) { Title = "CalculadoraFilamentoPro" };
        }

        private static async Task ExecuteDatabaseMigrationAsync(IServiceProvider services)
        {
            try
            {
                var migrationService = services.GetRequiredService<DatabaseMigrationHostedService>();
                await migrationService.StartAsync(CancellationToken.None);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Falha ao aplicar migrations: {exception}");
            }
        }
    }
}
