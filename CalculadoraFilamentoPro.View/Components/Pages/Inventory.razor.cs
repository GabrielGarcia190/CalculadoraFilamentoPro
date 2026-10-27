using Microsoft.AspNetCore.Components;
using CalculadoraFilamentoPro.Domain.Configurations.Repositories;
using CalculadoraFilamentoPro.Domain.Filaments.Entities;
using CalculadoraFilamentoPro.Domain.Filaments.Repositories;

namespace CalculadoraFilamentoPro.Components.Pages;

public partial class Inventory : ComponentBase
{
    [Inject] private IFilamentRepository FilamentRepository { get; set; } = default!;

    [Inject] private IConfigurationRepository ConfigurationRepository { get; set; } = default!;

    protected List<Filament> Filamentos { get; private set; } = [];

    protected Guid UserId { get; private set; }

    protected Filament? FilamentoSelecionado { get; private set; }

    protected bool MostrarModal { get; private set; }
    protected int Pagina = 1;

    protected string Categoria = "Todos";

    protected List<string> Categorias = new List<string>
    {
        "Todos",
        "PLA",
        "PETG",
        "ABS",
        "TPU",
        "Nylon CF"
    };

    protected override async Task OnInitializedAsync()
    {
        var configuration = await ConfigurationRepository.GetConfigurationAsync();
        if (configuration.LastUserId is Guid userId)
        {
            UserId = userId;
            await CarregarFilamentos();
        }
    }

    private async Task CarregarFilamentos()
    {
        Filamentos = (await FilamentRepository.GetFilamentsByUsersAsync(UserId)).ToList();
    }

    protected void NovoFilamento()
    {
        FilamentoSelecionado = null;
        MostrarModal = true;
    }

    protected async Task EditarFilamento(Guid id)
    {
        FilamentoSelecionado = Filamentos.FirstOrDefault(filament => filament.Id == id)
            ?? await FilamentRepository.FindByIdAsync(id);

        MostrarModal = FilamentoSelecionado is not null;
    }

    protected Task FecharModal()
    {
        MostrarModal = false;
        FilamentoSelecionado = null;
        return Task.CompletedTask;
    }

    protected async Task SalvarFilamento(Filament filament)
    {
        if (Filamentos.Any(existing => existing.Id == filament.Id))
            await FilamentRepository.SaveAsync(filament);
        else
            await FilamentRepository.AddAsync(filament);

        await CarregarFilamentos();
        await FecharModal();
    }

    protected Task OnPageChanged(int pagina)
    {
        Pagina = pagina;

        // futuramente carregar outra página

        return Task.CompletedTask;
    }

    protected Task OnCategoriaChanged(string categoria)
    {
        Categoria = categoria;

        // futuramente filtrar o grid

        return Task.CompletedTask;
    }
    private Task VisualizarFilamento(Guid id)
    {
        Console.WriteLine(id);

        return Task.CompletedTask;
    }
}