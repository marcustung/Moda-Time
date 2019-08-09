using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;
using System.Globalization;

namespace ModaTime.Test
{
    class ShortMonthNameOfYearTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("TestCases_ZHTW")]
        public void Get_ShortMonthNameOfYear_ZHTW(DateTime date, string dayText)
        {
            var actual = date.ShortMonthNameOfYear();
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
        public void Get_ShortMonthNameOfYear_ENUS(DateTime date, string dayText)
        {
            var actual = date.ShortMonthNameOfYear(CultureInfo.InvariantCulture);
            actual.Should().Be(dayText);
        }

        public static IEnumerable TestCases_ENUS
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 1), "Jan");
                yield return new TestCaseData(new DateTime(2019, 2, 1), "Feb");
                yield return new TestCaseData(new DateTime(2019, 3, 1), "Mar");
                yield return new TestCaseData(new DateTime(2019, 4, 1), "Apr");
                yield return new TestCaseData(new DateTime(2019, 5, 1), "May");
                yield return new TestCaseData(new DateTime(2019, 6, 1), "Jun");
                yield return new TestCaseData(new DateTime(2019, 7, 1), "Jul");
                yield return new TestCaseData(new DateTime(2019, 8, 1), "Aug");
                yield return new TestCaseData(new DateTime(2019, 9, 1), "Sep");
                yield return new TestCaseData(new DateTime(2019, 10, 1), "Oct");
                yield return new TestCaseData(new DateTime(2019, 11, 1), "Nov");
                yield return new TestCaseData(new DateTime(2019, 12, 1), "Dec");
            }
        }
    }
}
