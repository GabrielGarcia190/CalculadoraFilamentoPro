using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Setup
{
    public partial class ConnectionStringInput
    {
        [Parameter]
        public string ConnectionString { get; set; } = "";

        [Parameter]
        public EventCallback<string> ConnectionStringChanged { get; set; }

        [Parameter]
        public string Placeholder { get; set; } = "postgresql://postgres:senha@localhost:5432/print3d";
    }
}