using SmilyTimerUWP.Model;
using SmilyTimerUWP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SmilyTimerUWP
{
    
    public sealed partial class Settings : Page
    {
        private ObservableCollection<Animation> Animations;
        private ObservableCollection<TimerType> TimerTypes;
        private Animation animation;
        private TimerType timerType;

        private int SecDuration { get; set; }
        private int MinDuration { get; set; }
        private int HourDuration { get; set; }


        public Settings()
        {
            this.InitializeComponent();

            Animations = new ObservableCollection<Animation>();
            TimerTypes = new ObservableCollection<TimerType>();

            AnimationFactory.GetAnimations(Animations);
            TimerTypeFactory.GetTimerTypes(TimerTypes);
            
            AnimationComboBox.ItemsSource = Animations;
            AnimationComboBox.SelectedItem = Animations.FirstOrDefault();

            TimerTypeComboBox.ItemsSource = TimerTypes;
            TimerTypeComboBox.SelectedItem = TimerTypes.FirstOrDefault();

            SettingsSaveButton.IsEnabled = false;

            animation = AnimationFactory.GetAllAnimations().FirstOrDefault();
            timerType = TimerTypeFactory.GetAllTimerTypes().FirstOrDefault();

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
                AnimationType = animation,
                Duration = (SecDuration + (60 * MinDuration) + (3600 * HourDuration)),
                TimerType = timerType
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

        private void AnimationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            animation = (Animation)AnimationComboBox.SelectedValue;
        }

        private void TimerTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            timerType = (TimerType)TimerTypeComboBox.SelectedValue;
        }

        private void ValidateTextBoxes()
        {
            if (int.TryParse(SettingsSecsTextbox.Text, out int sduration) && int.TryParse(SettingsMinsTextbox.Text, out int mduration) && int.TryParse(SettingsHourTextbox.Text, out int hduration))
            {
                SecDuration = sduration;
                MinDuration = mduration;
                HourDuration = hduration;
                if (((HourDuration * 3600) + (MinDuration * 60) + SecDuration) > 0)
                {
                    SettingsSaveButton.IsEnabled = true;
                }
                else
                {
                    SettingsSaveButton.IsEnabled = false;
                }
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
                if (value > 0 && value < 60)
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
                if (value >= 0 && value < 59)
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
