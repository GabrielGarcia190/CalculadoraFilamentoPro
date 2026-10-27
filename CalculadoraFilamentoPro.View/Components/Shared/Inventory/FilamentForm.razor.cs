using System.Globalization;
using CalculadoraFilamentoPro.Domain.Filaments.Entities;
using CalculadoraFilamentoPro.Domain.Filaments.Enums;
using Microsoft.AspNetCore.Components;

namespace CalculadoraFilamentoPro.Components.Shared.Inventory;

public partial class FilamentForm
{
    [Parameter] public bool Visible { get; set; }
    [Parameter] public Guid UserId { get; set; }
    [Parameter] public Filament? FilamentParaEditar { get; set; }
    [Parameter] public EventCallback OnClose { get; set; }
    [Parameter] public EventCallback<Filament> OnSave { get; set; }

    private Guid? _loadedId;
    private string Nome { get; set; } = string.Empty;
    private string Marca { get; set; } = string.Empty;
    private string Cor { get; set; } = "#EAB308";
    private string CorHex { get; set; } = "#EAB308";
    private string TipoSelecionado { get; set; } = nameof(EFilamentType.PLA);
    private string Peso { get; set; } = "1000";
    private string Preco { get; set; } = "139,00";
    private string Frete { get; set; } = "0,00";
    private string? Erro { get; set; }

    private bool ModoEdicao => FilamentParaEditar is not null;

    private string CustoPorGrama
    {
        get
        {
            if (!TryParseDecimal(Peso, out var peso) || peso <= 0 || !TryParseDecimal(Preco, out var preco))
                return "R$ 0,000";

            TryParseDecimal(Frete, out var frete);
            return $"R$ {((preco + frete) / peso):N3}";
        }
    }

    protected override void OnParametersSet()
    {
        var currentId = FilamentParaEditar?.Id;
        if (_loadedId == currentId && (currentId is not null || Visible))
            return;

        _loadedId = currentId;
        Erro = null;

        if (FilamentParaEditar is null)
        {
            Nome = string.Empty;
            Marca = string.Empty;
            Cor = CorHex = "#EAB308";
            TipoSelecionado = nameof(EFilamentType.PLA);
            Peso = "1000";
            Preco = "139,00";
            Frete = "0,00";
            return;
        }

        Nome = FilamentParaEditar.Name;
        Marca = FilamentParaEditar.Brand;
        Cor = FilamentParaEditar.Color;
        CorHex = FilamentParaEditar.Color.StartsWith('#') ? FilamentParaEditar.Color : "#EAB308";
        TipoSelecionado = FilamentParaEditar.Type.ToString();
        Peso = FilamentParaEditar.OriginalWeight.ToString("0.##", CultureInfo.InvariantCulture);
        Preco = FilamentParaEditar.CostPrice.ToString("0.##", CultureInfo.CurrentCulture);
        Frete = "0,00";
    }

    private async Task Salvar()
    {
        try
        {
            if (!TryParseDecimal(Peso, out var peso) || !TryParseDecimal(Preco, out var preco) || !TryParseDecimal(Frete, out var frete))
                throw new ArgumentException("Informe valores numéricos válidos para peso, preço e frete.");

            if (!Enum.TryParse<EFilamentType>(TipoSelecionado, out var tipo))
                throw new ArgumentException("Selecione um tipo de polímero válido.");

            if (FilamentParaEditar is null)
            {
                if (UserId == Guid.Empty)
                    throw new InvalidOperationException("Não foi possível identificar o usuário atual.");

                FilamentParaEditar = Filament.Create(UserId, Nome, Cor, tipo, preco + frete, Marca, DateTime.Today, peso);
            }
            else
            {
                FilamentParaEditar.UpdateInformation(Nome, Cor, tipo, preco + frete, Marca, FilamentParaEditar.PurchaseDate, peso);
            }

            await OnSave.InvokeAsync(FilamentParaEditar);
        }
        catch (Exception exception)
        {
            Erro = exception.Message;
        }
    }

    private static bool TryParseDecimal(string value, out decimal result)
        => decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out result)
           || decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out result);

    private Task Close()
        => OnClose.InvokeAsync();
}