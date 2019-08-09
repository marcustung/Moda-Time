using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;

namespace ModaTime.Test
{
    class GetWeekOfYearTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("TestCases")]
        public void Get_MonthNameOfYear(DateTime date, int weekNumber)
        {
            var actual = date.GetWeekOfYear();
            actual.Should().Be(weekNumber);
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 2, 1), 5);
                yield return new TestCaseData(new DateTime(2019, 4, 1), 14);
                yield return new TestCaseData(new DateTime(2019, 6, 1), 22);
                yield return new TestCaseData(new DateTime(2019, 8, 7), 32);
                yield return new TestCaseData(new DateTime(2019, 10, 10), 41);
                yield return new TestCaseData(new DateTime(2019, 12, 12), 50);
            }
        }
    }
}
