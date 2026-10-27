using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Inventory;

public partial class FormSection
{
    [Parameter]
    public int Number { get; set; }

    [Parameter]
    public string Title { get; set; } = "";

    [Parameter]
    public string Description { get; set; } = "";

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}