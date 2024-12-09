using System.Windows;
using System.Windows.Controls;

namespace WPFFunkyInventory.UserControls;

public partial class SplashControl : UserControl
{
    public SplashControl()
    {
        InitializeComponent();
    }

    private void OnLoad(object sender, RoutedEventArgs e)
        => tbCopyright.Text = $"Funky Designs © {DateTime.Now:yyyy}";
}
