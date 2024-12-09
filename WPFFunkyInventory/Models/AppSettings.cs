using WPFFunkyInventory.Properties;

namespace WPFFunkyInventory.Models;

public class AppSettings
{
    public AppSettings()
    {
        Settings settings = Settings.Default;

        UserName = null;
        TokenExpiration = DateTime.Now;
    }

    public DateTime? TokenExpiration { get; set; }

    public string? UserName { get; set; }
}
