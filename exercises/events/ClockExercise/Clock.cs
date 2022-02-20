using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockExercise
{
    public class Clock
    {
        private int totalSeconds;
        public Clock(ITimerService timer)
        {
            timer.Tick += OnTick;
        }

        private void OnTick()
        {
            totalSeconds++;
            NotifySecondObservers();
            NotifyMinuteObservers();
            NotifyHourObservers();
            NotifyDayObservers();
        }

        private void NotifyDayObservers()
        {
            int secondsPerDay = 3600 * 24;
            if (totalSeconds % secondsPerDay == 0)
            {
                DayPassed?.Invoke(totalSeconds / secondsPerDay);
            }
        }

        private void NotifyHourObservers()
        {
            if (totalSeconds % 3600 == 0)
            {
                HourPassed?.Invoke(totalSeconds / 3600);
            }
        }

        private void NotifyMinuteObservers()
        {
            if (totalSeconds % 60 == 0)
            {
                MinutePassed?.Invoke(totalSeconds / 60);
            }
        }

        private void NotifySecondObservers()
        {
            SecondPassed?.Invoke(totalSeconds);
        }

        public event Action<int> SecondPassed;
        public event Action<int> MinutePassed;
        public event Action<int> HourPassed;
        public event Action<int> DayPassed;

    }
}
