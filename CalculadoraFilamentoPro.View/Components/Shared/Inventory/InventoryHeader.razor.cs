namespace CalculadoraFilamentoPro.Components.Shared.Inventory;

public partial class InventoryHeader
{
    private bool MostrarCadastro;

    private bool MostrarModal;

    private void AbrirModal()
    {
        MostrarModal = true;
    }

    private void FecharModal()
    {
        MostrarModal = false;
    }

    private void FecharCadastro()
    {
        MostrarCadastro = false;
    }

    private async Task SalvarFilamento()
    {
        MostrarCadastro = false;
    }
}