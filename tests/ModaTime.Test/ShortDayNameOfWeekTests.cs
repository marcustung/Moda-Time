using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;
using System.Globalization;

namespace JodaTimeLib.Test
{
    class ShortDateOfWeekTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("TestCases_zhtw")]
        public void Get_ShortDayNameOfWeek_ZHTW(DateTime date, string dayText)
        {
            var actual = date.ShortDayNameOfWeek();
            actual.Should().Be(dayText, $"{date} DayName should be {dayText}");
        }

        public static IEnumerable TestCases_zhtw
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 9, 1), "日");
                yield return new TestCaseData(new DateTime(2019, 9, 2), "一");
                yield return new TestCaseData(new DateTime(2019, 9, 3), "二");
                yield return new TestCaseData(new DateTime(2019, 9, 4), "三");
                yield return new TestCaseData(new DateTime(2019, 9, 5), "四");
                yield return new TestCaseData(new DateTime(2019, 9, 6), "五");
                yield return new TestCaseData(new DateTime(2019, 9, 7), "六");
            }
        }

        [Test, TestCaseSource("TestCases_enus")]
        public void Get_ShortDayNameOfWeek_ENUS(DateTime date, string dayText)
        {
            var actual = date.ShortDayNameOfWeek(CultureInfo.InvariantCulture);
            actual.Should().Be(dayText, $"{date} DayName should be {dayText}");
        }

        public static IEnumerable TestCases_enus
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 9, 1), "Sun");
                yield return new TestCaseData(new DateTime(2019, 9, 2), "Mon");
                yield return new TestCaseData(new DateTime(2019, 9, 3), "Tue");
                yield return new TestCaseData(new DateTime(2019, 9, 4), "Wed");
                yield return new TestCaseData(new DateTime(2019, 9, 5), "Thu");
                yield return new TestCaseData(new DateTime(2019, 9, 6), "Fri");
                yield return new TestCaseData(new DateTime(2019, 9, 7), "Sat");
            }
        }
    }
}
