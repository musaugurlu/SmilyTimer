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
        private int Duration;
        private int CountDownSeconds;
        private int CountUpSeconds = 0;
        private string CountType;
        private string AnimationType;
        private bool showAsClock = true;
        private DispatcherTimer timer;

        public TimerView()
        {
            this.InitializeComponent();
            ShowTimerAsClock(CountDownSeconds);
            this.NavigationCacheMode = NavigationCacheMode.Required;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            
        }

        private void Timer_Tick(object sender, object e)
        {
            if(CountType == "CountDown")
            {
                CountDownSeconds--;
                CountDown(CountDownSeconds);
            }
            else if (CountType == "CountUp")
            {
                CountUpSeconds++;
                CountUp(CountUpSeconds);
            }

            ShowTimerAsClock(CountDownSeconds);
        }
        
        private void GotoSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Frame.Navigate(typeof(Settings));

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = e.Parameter as TimerSetting;
            Duration = parameters.Duration;
            CountType = parameters.TimerType.Name;
            AnimationType = parameters.AnimationType.Name;

            if (CountType == "CountDown")
            {
                CountDownSeconds = Duration;
                ShowTimerAsClock(CountDownSeconds);
            }
                        
            SetButtonStates("Start");
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
            ShowTimerAsClock(CountDownSeconds);
        }

        private void ShowAsClockRadioButton_Click(object sender, RoutedEventArgs e)
        {
            showAsClock = true;
            ShowTimerAsClock(CountDownSeconds);
        }

        private void TimeViewStopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            CountDownSeconds = 0;
            ShowTimerAsClock(CountDownSeconds);
            SetButtonStates("Stop");
        }

        private void TimeViewStartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            SetButtonStates("Start");
        }

        private void TimeViewPauseButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            SetButtonStates("Pause");
        }

        private void SetButtonStates(string state)
        {
            switch (state)
            {
                case "Start":
                    GotoSettingsButton.IsEnabled = false;
                    TimeViewStartButton.IsEnabled = false;
                    TimeViewPauseButton.IsEnabled = true;
                    TimeViewStopButton.IsEnabled = true;
                    break;

                case "Pause":
                    GotoSettingsButton.IsEnabled = false;
                    TimeViewStartButton.IsEnabled = true;
                    TimeViewPauseButton.IsEnabled = false;
                    TimeViewStopButton.IsEnabled = true;
                    break;

                case "Stop":
                    GotoSettingsButton.IsEnabled = true;
                    TimeViewStartButton.IsEnabled = false;
                    TimeViewPauseButton.IsEnabled = false;
                    TimeViewStopButton.IsEnabled = false;
                    break;
            }
        }

        private void CountDown(int Seconds)
        {
            if (Seconds < 1)
            {
                timer.Stop();
                CountDownSeconds = 0;
                SetButtonStates("Stop");
            }
        }


        private void CountUp(int Seconds)
        {

        }
    }
}
