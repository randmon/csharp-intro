using System;

namespace TimeExercise
{
    public class Time
    {
        public Time(int hours, int minutes, int seconds)
        {
            TotalSeconds = hours * 60 * 60 + minutes * 60 + seconds;
        }

        public int TotalSeconds { get; }

        public int Seconds => TotalSeconds % 60;

        public int Minutes => (TotalSeconds / 60) % 60;

        public int Hours => TotalSeconds / 60 / 60;
    }
}
