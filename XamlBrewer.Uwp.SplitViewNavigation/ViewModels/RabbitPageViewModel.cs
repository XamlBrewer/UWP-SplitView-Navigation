using System.Windows.Input;
using Mvvm;
using Mvvm.Services;

namespace XamlBrewer.Uwp.SplitViewNavigation.ViewModels
{
    public class RabbitPageViewModel : BindableBase
    {
        public ICommand SettingsCommand
        {
            get { return new DelegateCommand(() => Navigation.Navigate(typeof(SettingsPage))); }
        }
    }
}
