using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmilyTimerUWP.Model
{
    public class TimerType
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public TimerType(string timerType)
        {
            this.Name = timerType;
        }
    }

    public class TimerTypeFactory
    {
        public static void GetTimerTypes(ObservableCollection<TimerType> TimerTypes)
        {
            var alltimertypes = GetAllTimerTypes();
            TimerTypes.Clear();
            alltimertypes.ForEach(t => TimerTypes.Add(t));

        }

        public static List<TimerType> GetAllTimerTypes()
        {
            var timertypes = new List<TimerType>
            {
                new TimerType("CountDown"),
                new TimerType("CountUp")
            };

            return timertypes;
        }
    }
}
