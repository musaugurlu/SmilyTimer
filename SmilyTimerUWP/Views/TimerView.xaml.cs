using SmilyTimerUWP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

namespace SmilyTimerUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TimerView : Page
    {
        private int Seconds;
        private DispatcherTimer timer;

        public TimerView()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, object e)
        {
            Seconds = Seconds - 1;
            TimeTextBlock.Text = Seconds.ToString();
            if (Seconds == 0)
            {
                timer.Stop();
                GotoSettingsButton.IsEnabled = true;
            }
        }

        private void GotoSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            GotoSettingsButton.IsEnabled = false;
            TimeTextBlock.Text = Seconds.ToString();
            timer.Start();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = e.Parameter as TimerSetting;
            Seconds = parameters.Duration;
        }

    }
}
