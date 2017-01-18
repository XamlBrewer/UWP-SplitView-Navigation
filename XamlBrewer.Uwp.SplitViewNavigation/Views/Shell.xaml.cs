using System;
using System.Diagnostics;
using Mvvm;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Mvvm.Services;

namespace XamlBrewer.Uwp.SplitViewNavigation
{
    public sealed partial class Shell
    {
        public Shell()
        {
            InitializeComponent();

            // Navigate to the home page.
            Navigation.Frame = SplitViewFrame;
            Navigation.Navigate(typeof(MainPage));
        }

        // Navigate to another page.
        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                // Unselect the other menu.
                if ((sender as ListView) == Menu)
                {
                    SecondMenu.SelectedItem = null;
                }
                else
                {
                    Menu.SelectedItem = null;
                }

                var menuItem = e.AddedItems.First() as MenuItem;
                if (menuItem != null && menuItem.IsNavigation)
                {
                    Navigation.Navigate(menuItem.NavigationDestination);
                }
            }
        }

        // Execute command.
        private void Menu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;

            if (menuItem != null && !menuItem.IsNavigation)
            {
                Debugger.Break();
                menuItem.Command.Execute(null);
            }
        }

        // Swipe to open the splitview panel.
        private void SplitViewOpener_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > 50)
            {
                MySplitView.IsPaneOpen = true;
            }
        }

        // Swipe to close the splitview panel.
        private void SplitViewPane_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                MySplitView.IsPaneOpen = false;
            }
        }

        // Open or close the splitview panel through Hamburger button.
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            // Lookup destination type in menu(s)
            var item = (from i in Menu.Items
                where (i as MenuItem).NavigationDestination == e.SourcePageType
                select i).FirstOrDefault();
            if (item != null)
            {
                Menu.SelectedItem = item;
                return;
            }

            item = (from i in SecondMenu.Items
                    where (i as MenuItem).NavigationDestination == e.SourcePageType
                    select i).FirstOrDefault();
            if (item != null)
            {
                SecondMenu.SelectedItem = item;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += Shell_BackRequested;
            base.OnNavigatedTo(e);
        }

        private static void Shell_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Navigation.GoBack();
        }
    }
}
