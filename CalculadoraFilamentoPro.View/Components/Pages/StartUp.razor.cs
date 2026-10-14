using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Pages
{
    public partial class StartUp
    {
        //[Inject]
        //ConfigurationService Configuration { get; set; } = default!;

        //[Inject]
        //NavigationManager Navigation { get; set; } = default!;

        //[Inject]
        //ConfigurationService Service { get; set; } = default!;

        //protected string Mensagem = "Inicializando...";

        //protected int Progresso;

        //protected override async Task OnInitializedAsync()
        //{
        //    await Atualizar("Carregando configurações...", 20);

        //    var settings = await Configuration.Load();

        //    if (settings is null)
        //    {
        //        Navigation.NavigateTo("/setup/database", true);
        //        return;
        //    }

        //    await Atualizar("Validando banco de dados...", 45);

        //    var conectado = await Service.TestConnection(settings.Provider, settings.ConnectionString);

        //    if (!conectado)
        //    {
        //        Navigation.NavigateTo("/setup/database", true);
        //        return;
        //    }

        //    await Atualizar("Inicializando serviços...", 75);

        //    await Task.Delay(400);

        //    await Atualizar("Abrindo sistema...", 100);

        //    await Task.Delay(250);

        //    Navigation.NavigateTo("/login", true);
        //}

        //async Task Atualizar(string texto, int progresso)
        //{
        //    Mensagem = texto;
        //    Progresso = progresso;

        //    StateHasChanged();

        //    await Task.Delay(350);
        //}
    }
}