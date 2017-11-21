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
        private int secDuration { get; set; }
        private int minDuration { get; set; }
        private int hourDuration { get; set; }


        public Settings()
        {
            this.InitializeComponent();
        }

        private void SecsDownButton_Click(object sender, RoutedEventArgs e)
        {
            CountDownTextbox(SettingsSecsTextbox);
        }
        
        private void SecsUpButton_Click(object sender, RoutedEventArgs e)
        {
            CountUpTextbox(SettingsSecsTextbox);
        }

        private void MinsDownButton_Click(object sender, RoutedEventArgs e)
        {
            CountDownTextbox(SettingsMinsTextbox);
        }

        private void MinsUpButton_Click(object sender, RoutedEventArgs e)
        {
            CountUpTextbox(SettingsMinsTextbox);
        }

        private void HoursUpButton_Click(object sender, RoutedEventArgs e)
        {
            CountUpTextbox(SettingsHourTextbox);
        }

        private void HoursDownButton_Click(object sender, RoutedEventArgs e)
        {
            CountDownTextbox(SettingsHourTextbox);
        }

        private void SettingsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new TimerSetting()
            {
                AnimationType = AnimationType.Candle,
                Duration = (secDuration + (60 * minDuration) + (3600 * hourDuration)),
                TimerType = TimerType.CountDown
            };

            Frame.Navigate(typeof(TimerView), parameters);
        }

        private void SettingsSecsTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            ValidateTextBoxes();
        }

        private void SettingsMinsTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            ValidateTextBoxes();

        }

        private void SettingsHourTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            ValidateTextBoxes();
        }

        private void ValidateTextBoxes()
        {
            if (int.TryParse(SettingsSecsTextbox.Text, out int sduration) && int.TryParse(SettingsMinsTextbox.Text, out int mduration) && int.TryParse(SettingsHourTextbox.Text, out int hduration))
            {
                secDuration = sduration;
                minDuration = mduration;
                hourDuration = hduration;

                SettingsSaveButton.IsEnabled = true;
            }
            else
            {
                SettingsSaveButton.IsEnabled = false;
            }
        }

        private void CountDownTextbox(object textBox)
        {
            TextBox _textBox = textBox as TextBox;

            if (int.TryParse(_textBox.Text, out int value))
            {
                if (value > 0)
                {
                    value--;
                    _textBox.Text = value.ToString();
                }
                else
                {
                    _textBox.Text = "00";
                }
            }
            else
            {
                _textBox.Text = "00";
            }
        }

        private void CountUpTextbox(object textBox)
        {
            TextBox _textBox = textBox as TextBox;

            if (int.TryParse(_textBox.Text, out int value))
            {
                if (value >= 0)
                {
                    value++;
                    _textBox.Text = value.ToString();
                }
                else
                {
                    _textBox.Text = "00";
                }
            }
            else
            {
                _textBox.Text = "00";
            }

        }

    }
}
