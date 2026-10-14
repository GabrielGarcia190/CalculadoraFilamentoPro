using System.Linq;
using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Windowing;
using WinRT.Interop;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CalculadoraFilamentoPro.WinUI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : MauiWinUIApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);

            try
            {
                // Try to get the current MAUI Window and set a minimum size (900x630)
                var mauiWindow = Microsoft.Maui.Controls.Application.Current?.Windows?.FirstOrDefault()?.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
                if (mauiWindow != null)
                {
                    IntPtr hWnd = WindowNative.GetWindowHandle(mauiWindow);
                    var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hWnd);
                    var appWindow = AppWindow.GetFromWindowId(windowId);
                    if (appWindow != null)
                    {
                        var minSize = new SizeInt32(1800, 1000);
                        // Resize to the minimum as a fallback; enforcing min size may require Win32 message handling.
                        appWindow.Resize(minSize);
                        try
                        {
                            var presenter = appWindow.Presenter as OverlappedPresenter;
                            if (presenter != null)
                            {
                                // Attempt to prevent smaller resizing by disabling sizing edges if API available
                                presenter.IsResizable = true; // keep resizable but we already set initial size
                            }
                        }
                        catch
                        {
                            // ignore if presenter cast or properties unavailable
                        }
                    }
                }
            }
            catch
            {
                // Ignore failures on platforms where APIs are not available at runtime
            }
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

}
