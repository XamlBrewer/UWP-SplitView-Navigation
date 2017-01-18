using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Mvvm;
using Mvvm.Services;

namespace XamlBrewer.Uwp.SplitViewNavigation
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        public ICommand AboutCommand => new DelegateCommand(() => Navigation.Navigate(typeof(AboutPage)));
    }
}
