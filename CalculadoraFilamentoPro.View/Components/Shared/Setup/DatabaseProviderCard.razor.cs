using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Setup
{
    public partial class DatabaseProviderCard
    {
        [Parameter]
        public string Icon { get; set; } = "";

        [Parameter]
        public string Title { get; set; } = "";

        [Parameter]
        public string Subtitle { get; set; } = "";

        [Parameter]
        public bool Selected { get; set; }

        [Parameter]
        public EventCallback OnClick { get; set; }

        private async Task Selecionar()
        {
            await OnClick.InvokeAsync();
        }
    }
}