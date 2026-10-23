using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Pages;

public partial class Inventory : ComponentBase
{
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