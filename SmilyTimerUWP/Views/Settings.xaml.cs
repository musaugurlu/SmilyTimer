using SmilyTimerUWP.Model;
using SmilyTimerUWP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SmilyTimerUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {

        public Settings()
        {
            this.InitializeComponent();
        }

        private void SecsDownButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SecsUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinsDownButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MinsUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HoursUpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HoursDownButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(SettingsSecsTextbox.Text, out int duration))
            {
                SettingsSaveButton.IsEnabled = false;
            }
            else
            {
                SettingsSaveButton.IsEnabled = true;
            }

            var parameters = new TimerSetting()
            {
                AnimationType = AnimationType.Candle,
                Duration = duration,
                TimerType = TimerType.CountDown
            };

            Frame.Navigate(typeof(TimerView), parameters);
        }
    }
}
