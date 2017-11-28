using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmilyTimerUWP.Model
{
    public class TimerSetting
    {
        public TimerType TimerType { get; set; }
        public int Duration { get; set; }
        public Animation AnimationType { get; set; }
    }
}
