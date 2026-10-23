using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Shared;

public partial class Modal
{
    [Parameter]
    public bool Visible { get; set; }

    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public string Subtitle { get; set; } = string.Empty;

    [Parameter]
    public string Icon { get; set; } = "bi bi-plus-circle";

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback OnClose { get; set; }

    protected async Task Close()
    {
        if (OnClose.HasDelegate)
            await OnClose.InvokeAsync();
    }
}