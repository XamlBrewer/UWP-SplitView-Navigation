using Mvvm.Services;
using XamlBrewer.Uwp.SplitViewNavigation;

namespace Mvvm
{
    internal class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menus
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("BirdIcon"), Text = "Bird", NavigationDestination = typeof(BirdPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("DonkeyIcon"), Text = "Donkey", NavigationDestination = typeof(DonkeyPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("HorseIcon"), Text = "Horse", NavigationDestination = typeof(HorsePage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("RabbitIcon"), Text = "Rabbit", NavigationDestination = typeof(RabbitPage) });

            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("GearIcon"), Text = "Settings", NavigationDestination = typeof(SettingsPage) });
            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("InfoIcon"), Text = "About", NavigationDestination = typeof(AboutPage) });
        }
    }
}
