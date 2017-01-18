using System;
using Windows.UI.Xaml.Controls;

namespace Mvvm.Services
{
    public static class Navigation
    {
        private static Frame _frame;

        public static Frame Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }

        public static bool Navigate(Type sourcePageType)
        {
            if (_frame.CurrentSourcePageType != sourcePageType)
            {
                return _frame.Navigate(sourcePageType);
            }

            return true;
        }

        public static void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }
    }
}
