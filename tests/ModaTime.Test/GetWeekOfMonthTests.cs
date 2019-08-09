
using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;

namespace JodaTimeLib.Test
{
    class GetWeekOfMonthTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("TestCases")]
        public void Get_MonthNameOfMonth(DateTime date, int weekNumber)
        {
            var actual = date.GetWeekOfMonth();
            actual.Should().Be(weekNumber);
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 1), 1);
                yield return new TestCaseData(new DateTime(2019, 3, 5), 2);
                yield return new TestCaseData(new DateTime(2019, 5, 10), 2);
                yield return new TestCaseData(new DateTime(2019, 7, 15), 3);
                yield return new TestCaseData(new DateTime(2019, 9, 20), 3);
                yield return new TestCaseData(new DateTime(2019, 11, 25), 5);
            }
        }
    }
}
