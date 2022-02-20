namespace FormattingExercise
{
    public class Formatter
    {
        public static string Greet(string name)
        {
            return $"Hello, {name}";
        }

        public static string FormatDate(int day, int month, int year)
        {
            return $"{day:00}/{month:00}/{year}";
        }
    }
}
