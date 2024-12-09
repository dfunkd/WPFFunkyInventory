using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Windows;
using WPFFunkyInventory.UserControls;
using WPFFunkyInventory.ViewModels;
using WPFFunkyInventory.Windows;

//https://gist.github.com/sajidmohammed88/99928bbb3e94028fc6be175d67c0b46f
namespace WPFFunkyInventory;

public partial class App : Application
{
    #region Windows
    public InventoryWindow InventoryWindow;
    #endregion

    #region Controls
    public TitleControl TitleControl;
    #endregion

    public App()
    {
        ServiceCollection serviceCollection = new();
        serviceCollection.ConfigureServices();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        InventoryWindow = serviceProvider.GetRequiredService<InventoryWindow>();
        InventoryWindow.Show();
        //RegistrationWindow = serviceProvider.GetRequiredService<RegistrationWindow>();
        TitleControl = serviceProvider.GetRequiredService<TitleControl>();
    }
}

public static class ServiceCollectionExtensions
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        //services.AddSingleton<LoginWindowViewModel>();
        //services.AddSingleton<LoginWindow>();

        services.AddSingleton<InventoryWindowViewModel>();
        services.AddSingleton<InventoryWindow>();

        //services.AddSingleton<RegistrationWindowViewModel>();
        //services.AddSingleton<RegistrationWindow>();

        services.AddSingleton<TitleControl>();

        services.AddSingleton<HttpClient>();

        //services.AddScoped<IHttpManager, HttpManager>();

        //services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<IUserService, UserService>();
    }
}
