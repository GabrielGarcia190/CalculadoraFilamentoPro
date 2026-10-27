using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Inventory;

public partial class InventoryHeader
{
    [Parameter]
    public EventCallback OnNewFilament { get; set; }

    private Task AbrirModal()
        => OnNewFilament.InvokeAsync();
}