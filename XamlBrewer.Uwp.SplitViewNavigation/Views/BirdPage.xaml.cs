using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Mvvm.Services;

namespace XamlBrewer.Uwp.SplitViewNavigation
{
    public sealed partial class BirdPage : Page
    {
        public BirdPage()
        {
            this.InitializeComponent();
        }

        private void RabbitButton_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(typeof(RabbitPage));
        }
    }
}
