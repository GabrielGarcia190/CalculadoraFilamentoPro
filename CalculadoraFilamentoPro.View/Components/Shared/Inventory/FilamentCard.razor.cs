using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Inventory
{
    public partial class FilamentCard
    {
        [Parameter] public Guid Id { get; set; }

        [Parameter] public string Codigo { get; set; } = string.Empty;

        [Parameter] public string Material { get; set; } = string.Empty;

        [Parameter] public string MaterialClass { get; set; } = string.Empty;

        [Parameter] public string Status { get; set; } = string.Empty;

        [Parameter] public string StatusClass { get; set; } = string.Empty;

        [Parameter] public string Nome { get; set; } = string.Empty;

        [Parameter] public string Marca { get; set; } = string.Empty;

        [Parameter] public string Cor { get; set; } = string.Empty;

        [Parameter] public string Imagem { get; set; } = "/images/filaments/default.png";

        [Parameter] public decimal PesoAtual { get; set; }

        [Parameter] public decimal PesoOriginal { get; set; }

        [Parameter] public decimal ValorCompra { get; set; }

        [Parameter] public decimal ValorGrama { get; set; }

        [Parameter] public string Fornecedor { get; set; } = string.Empty;

        [Parameter] public DateTime DataEntrada { get; set; }

        [Parameter] public EventCallback<Guid> OnVisualizar { get; set; }

        protected int Percentual =>
            PesoOriginal <= 0
                ? 0
                : (int)Math.Round((PesoAtual / PesoOriginal) * 100);

        protected string PesoAtualFormatado =>
            $"{PesoAtual:N0}g";

        protected string PesoOriginalFormatado =>
            $"{PesoOriginal:N0}g";

        protected string ValorCompraFormatado =>
            $"R$ {ValorCompra:N2}";

        protected string ValorGramaFormatado =>
            $"R$ {ValorGrama:N3}";

        protected string DataEntradaFormatada =>
            DataEntrada.ToString("dd/MM/yyyy");

        protected Task VisualizarDetalhes()
            => OnVisualizar.InvokeAsync(Id);
    }
}
