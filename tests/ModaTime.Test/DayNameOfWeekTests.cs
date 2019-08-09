using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;

namespace ModaTime.Test
{
    class DayNameOfWeekTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("TestCaseData_zhtw")]
        public void Get_DayNameOfWeek(DateTime date, string dayText)
        {
            var actual = date.DayNameOfWeek();
            actual.Should().Be(dayText);
        }

        public static IEnumerable TestCaseData_zhtw
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 4, 1), "星期一");
                yield return new TestCaseData(new DateTime(2019, 4, 2), "星期二");
                yield return new TestCaseData(new DateTime(2019, 4, 3), "星期三");
                yield return new TestCaseData(new DateTime(2019, 4, 4), "星期四");
                yield return new TestCaseData(new DateTime(2019, 4, 5), "星期五");
                yield return new TestCaseData(new DateTime(2019, 4, 6), "星期六");
                yield return new TestCaseData(new DateTime(2019, 4, 7), "星期日");
            }
        }
    }
}
