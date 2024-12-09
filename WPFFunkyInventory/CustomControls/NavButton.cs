using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace WPFFunkyInventory.CustomControls;

public class NavButton : ListBoxItem
{
    public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(NavButton));
    public event RoutedEventHandler Click
    {
        add => AddHandler(ClickEvent, value);
        remove => RemoveHandler(ClickEvent, value);
    }

    static NavButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
    }

    public Uri NavLink
    {
        get { return (Uri)GetValue(NavLinkProperty); }
        set { SetValue(NavLinkProperty, value); }
    }
    public static readonly DependencyProperty NavLinkProperty =
        DependencyProperty.Register("NavLink", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));

    public Geometry Icon
    {
        get { return (Geometry)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(Geometry), typeof(NavButton), new PropertyMetadata(null));
}
