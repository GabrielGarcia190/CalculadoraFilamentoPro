using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Inventory;

public partial class FilamentForm
{
    [Parameter]
    public bool Visible { get; set; }

    [Parameter]
    public EventCallback OnClose { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    private async Task Salvar()
    {
        // Repository.Add(...)

        await OnSave.InvokeAsync();
    }

    private async Task Close()
    {
        await OnClose.InvokeAsync();
    }
}
