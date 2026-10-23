namespace CalculadoraFilamentoPro.Components.Shared.Inventory;

public partial class InventoryHeader
{
    private bool MostrarModal;

    private void AbrirModal()
    {
        MostrarModal = true;
    }

    private void FecharModal()
    {
        MostrarModal = false;
    }
}