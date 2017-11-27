using SmilyTimerUWP.Model;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SmilyTimerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimerView : Page
    {
        private int Seconds;
        private bool showAsClock = true;
        private DispatcherTimer timer;

        public TimerView()
        {
            this.InitializeComponent();
            GotoSettingsButton.IsEnabled = false;
            ShowTimerAsClock(Seconds);
            this.NavigationCacheMode = NavigationCacheMode.Required;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            Seconds = Seconds - 1;
            if (Seconds < 1)
            {
                timer.Stop();
                Seconds = 0;
                GotoSettingsButton.IsEnabled = true;
            }

            ShowTimerAsClock(Seconds);
        }

        private void GotoSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Frame.Navigate(typeof(Settings));

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = e.Parameter as TimerSetting;
            Seconds = parameters.Duration;
            ShowTimerAsClock(Seconds);
            timer.Start();
        }

        private void ShowTimerAsClock(int secondsLeft)
        {
            if (showAsClock)
            {
                TimeSpan ts = TimeSpan.FromSeconds(secondsLeft);
                TimeTextBlock.Text = ts.ToString(@"hh\:mm\:ss");
            }
            else
            {
                TimeTextBlock.Text = secondsLeft.ToString();
            }
        }

        private void ShowAsSecRadioButton_Click(object sender, RoutedEventArgs e)
        {
            showAsClock = false;
            ShowTimerAsClock(Seconds);
        }

        private void ShowAsClockRadioButton_Click(object sender, RoutedEventArgs e)
        {
            showAsClock = true;
            ShowTimerAsClock(Seconds);
        }
    }
}
