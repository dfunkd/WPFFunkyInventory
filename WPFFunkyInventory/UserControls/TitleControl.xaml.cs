using System.Windows;
using System.Windows.Controls;

namespace WPFFunkyInventory.UserControls;

public partial class TitleControl : UserControl
{
    #region RoutedCommands
    #endregion

    public TitleControl()
    {
        InitializeComponent();
    }

    private void OnLoad(object sender, RoutedEventArgs e)
    {
        dpContent.Children.Clear();
        dpContent.Children.Add(new SplashControl());
    }
}
