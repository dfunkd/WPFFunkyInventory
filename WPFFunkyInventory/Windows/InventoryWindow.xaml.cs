using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using WPFFunkyInventory.Models;
using WPFFunkyInventory.UserControls;
using WPFFunkyInventory.ViewModels;

namespace WPFFunkyInventory.Windows;

public partial class InventoryWindow : Window
{
    #region Properties
    public App App;
    public AppSettings AppSettings;
    public CancellationToken CancellationToken = default;
    public DispatcherTimer LogTimer = new();
    #endregion

    #region RoutedCommands
    #region CloseCommand
    private static readonly RoutedCommand closeCommand = new();
    public static RoutedCommand CloseCommand = closeCommand;
    private void CanExecuteCloseCommand(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = e.Source is Control;
    }
    private void ExecutedCloseCommand(object sender, ExecutedRoutedEventArgs e)
    {
        Close();
    }
    #endregion
    #endregion

    public InventoryWindow(InventoryWindowViewModel vm)
    {
        InitializeComponent();

        LogTimer.Tick += OnLogTimerTick;

        App = App.Current as App;
        if (App is null)
            Close();
        AppSettings = new();
        DataContext = vm;
    }

    #region Events
    private void OnDrag(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        //LogTimer.Interval = TimeSpan.FromSeconds(1);
        //LogTimer.Start();

        dpContent.Children.Clear();
        dpContent.Children.Add(new TitleControl());
    }

    private void OnLogTimerTick(object? sender, EventArgs e)
    {        
        //logout
        if (AppSettings.TokenExpiration < DateTime.Now && (dpContent.Children.Count > 0 && dpContent.Children[0].GetType() != typeof(LoginControl)))
        {
            AppSettings.UserName = null;
            AppSettings.TokenExpiration = DateTime.Now;
            dpContent.Children.Clear();
        }
    }
    #endregion
}
