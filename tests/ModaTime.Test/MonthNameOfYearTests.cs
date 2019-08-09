using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;
using System.Globalization;

namespace ModaTime.Test
{
    class MonthTextOfYearTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("TestCases_ZHTW")]
        public void Get_MonthNameOfYear_ZHTW(DateTime date, string dayText)
        {
            var actual = date.MonthNameOfYear();
            actual.Should().Be(dayText);
        }

        public static IEnumerable TestCases_ZHTW
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 1), "一月");
                yield return new TestCaseData(new DateTime(2019, 2, 1), "二月");
                yield return new TestCaseData(new DateTime(2019, 3, 1), "三月");
                yield return new TestCaseData(new DateTime(2019, 4, 1), "四月");
                yield return new TestCaseData(new DateTime(2019, 5, 1), "五月");
                yield return new TestCaseData(new DateTime(2019, 6, 1), "六月");
                yield return new TestCaseData(new DateTime(2019, 7, 1), "七月");
                yield return new TestCaseData(new DateTime(2019, 8, 1), "八月");
                yield return new TestCaseData(new DateTime(2019, 9, 1), "九月");
                yield return new TestCaseData(new DateTime(2019, 10, 1), "十月");
                yield return new TestCaseData(new DateTime(2019, 11, 1), "十一月");
                yield return new TestCaseData(new DateTime(2019, 12, 1), "十二月");

            }
        }

        [Test, TestCaseSource("TestCases_ENUS")]
        public void Get_MonthNameOfYear_ENUS(DateTime date, string dayText)
        {
            var actual = date.MonthNameOfYear(CultureInfo.InvariantCulture);
            actual.Should().Be(dayText);
        }

        public static IEnumerable TestCases_ENUS
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 1), "January");
                yield return new TestCaseData(new DateTime(2019, 2, 1), "February");
                yield return new TestCaseData(new DateTime(2019, 3, 1), "March");
                yield return new TestCaseData(new DateTime(2019, 4, 1), "April");
                yield return new TestCaseData(new DateTime(2019, 5, 1), "May");
                yield return new TestCaseData(new DateTime(2019, 6, 1), "June");
                yield return new TestCaseData(new DateTime(2019, 7, 1), "July");
                yield return new TestCaseData(new DateTime(2019, 8, 1), "August");
                yield return new TestCaseData(new DateTime(2019, 9, 1), "September");
                yield return new TestCaseData(new DateTime(2019, 10, 1), "October");
                yield return new TestCaseData(new DateTime(2019, 11, 1), "November");
                yield return new TestCaseData(new DateTime(2019, 12, 1), "December");
            }
        }
    }
}
