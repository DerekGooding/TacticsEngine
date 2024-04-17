using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;

namespace TacticsEngine.Visualization.Views;

public partial class MainView : UserControl
{
    public MainView() => InitializeComponent();

    private void About_Click(object? sender, RoutedEventArgs e) => new AboutWindow().Show();

    private void Exit_Click(object? sender, RoutedEventArgs e)
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.Shutdown();
    }
}
