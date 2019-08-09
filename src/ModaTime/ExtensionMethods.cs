using System;
using System.Globalization;

namespace ModaTime
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Add the custom number of year to the value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime PlusYears(this DateTime date, int value)
        {
            if (value < -10000 || value > 10000)
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRange DateTimeBadYears");
            }

            return date.AddYears(value);
        }
        /// <summary>
        /// Add the custom number of month to the value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime PlusMonths(this DateTime date, int value)
        {
            if (value < -120000 || value > 120000)
            {
                throw new ArgumentOutOfRangeException("ArgumentOutOfRange DateTimeBadMonths");
            }

            return date.AddMonths(value);
        }
        /// <summary>
        /// Add the custom number of day to the value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime PlusDays(this DateTime date, int value)
        {
            return date.AddDays(value);
        }
        /// <summary>
        /// Add the custom number of hour to the value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime PlusHours(this DateTime date, double value)
        {
            return date.AddHours(value);
        }
        /// <summary>
        /// Add the custom number of minute to the value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime PlusMinutes(this DateTime date, double value)
        {
            return date.AddMinutes(value);
        }
        /// <summary>
        /// Add the custom number of second to the value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime PlusSeconds(this DateTime date, double value)
        {
            return date.AddSeconds(value);
        }
        /// <summary>
        /// Add the custom number of milliseconds to the value
        /// </summary>
        /// <param name="date"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime PlusMilliseconds(this DateTime date, double value)
        {
            return date.AddMilliseconds(value);
        }

        /// <summary>
        /// Get the day name of week
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string DayNameOfWeek(this DateTime date)
        {
            return date.ToString("dddd");
        }
        /// <summary>
        /// Get the day short name of week
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ShortDayNameOfWeek(this DateTime date)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetShortestDayName(date.DayOfWeek);
        }
        /// <summary>
        /// Get the day short name of week
        /// </summary>
        /// <param name="date"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ShortDayNameOfWeek(this DateTime date, CultureInfo culture)
        {
            return date.ToString("ddd", culture);
        }
        /// <summary>
        /// Get the Month Name of Year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string MonthNameOfYear(this DateTime date)
        {
            return date.ToString("MMMM");
        }
        /// <summary>
        /// Get the Month Name of Year
        /// </summary>
        /// <param name="date"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string MonthNameOfYear(this DateTime date, CultureInfo culture)
        {
            return date.ToString("MMMM", culture);
        }
        /// <summary>
        /// Get the Month short Name of Year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ShortMonthNameOfYear(this DateTime date)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
            //return date.ToString("MMM");
        }
        /// <summary>
        /// Get the Month short Name of Year
        /// </summary>
        /// <param name="date"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static string ShortMonthNameOfYear(this DateTime date, CultureInfo culture)
        {
            return culture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
        }
        /// <summary>
        /// Week of the year
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetWeekOfYear(this DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        /// <summary>
        /// Week of the Month
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetWeekOfMonth(this DateTime date)
        {
            var beginningOfMonth = new DateTime(date.Year, date.Month, 1);

            while (date.Date.AddDays(1).DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
            {
                date = date.AddDays(1);
            }

            return (int)Math.Truncate((double)date.Subtract(beginningOfMonth).TotalDays / 7f) + 1;
        }
        /// <summary>
        /// Get last day of a month
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int GetEndDayOfMonth(this DateTime date)
        {
            var nextMonthFirstDay = date.AddMonths(1).ToString("01-MM-yyyy");
            if (DateTime.TryParseExact(nextMonthFirstDay, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var lastDayOfMonth))
            {
                lastDayOfMonth = lastDayOfMonth.AddDays(-1);
            }
            return lastDayOfMonth.Day;
        }

        /// <summary>
        /// source is later than target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsAfter(this DateTime source, DateTime target)
        {
            return DateTime.Compare(source, target) > 0;
        }
        /// <summary>
        /// source is earlier than target.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsBefore(this DateTime source, DateTime target)
        {
            return DateTime.Compare(source, target) < 0;
        }
        /// <summary>
        /// source is the same as target.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEqual(this DateTime source, DateTime target)
        {
            return DateTime.Compare(source, target) == 0;
        }
        /// <summary>
        /// Compares two instances of DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>TimeSpan</returns>
        public static TimeSpan Compare(this DateTime source, DateTime target)
        {
            return CompareDiffDate(source, target);
        }
        /// <summary>
        /// Compares two instances of DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>TotalDays</returns>
        public static double GetCompareTotalDays(this DateTime source, DateTime target)
        {
            return CompareDiffDate(source, target).TotalDays;
        }
        /// <summary>
        /// Compares two instances of DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>TotalHours</returns>
        public static double GetCompareTotalHours(this DateTime source, DateTime target)
        {
            return CompareDiffDate(source, target).TotalHours;
        }
        /// <summary>
        /// Compares two instances of DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>Minute</returns>
        public static double GetCompareTotalMinute(this DateTime source, DateTime target)
        {
            return CompareDiffDate(source, target).TotalMinutes;
        }
        /// <summary>
        /// Compares two instances of DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>Second</returns>
        public static double GetCompareTotalSecond(this DateTime source, DateTime target)
        {
            return CompareDiffDate(source, target).TotalSeconds;
        }
        /// <summary>
        /// Compares two instances of DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>Milliseconds</returns>
        public static double GetCompareTotalMilliseconds(this DateTime source, DateTime target)
        {
            return CompareDiffDate(source, target).TotalMilliseconds;
        }
        /// <summary>
        /// Compares two instances of DateTime
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>TimeSpan</returns>
        private static TimeSpan CompareDiffDate(DateTime source, DateTime target)
        {
            return new TimeSpan(source.Ticks - target.Ticks);
        }
    }
}
