namespace CalculadoraFilamentoPro.View
{
    public partial class App : IApplication
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "CalculadoraFilamentoPro" };
        }
    }
}
