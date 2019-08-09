using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;

namespace JodaTimeLib.Test
{
    class GetEndDayOfMonthTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("TestCases")]
        public void Get_EndDayOfMonth(DateTime date, int endDay)
        {
            var actual = date.GetEndDayOfMonth();
            actual.Should().Be(endDay);
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 1), 31);
                yield return new TestCaseData(new DateTime(2019, 2, 1), 28);
                yield return new TestCaseData(new DateTime(2019, 3, 1), 31);
                yield return new TestCaseData(new DateTime(2019, 4, 1), 30);
                yield return new TestCaseData(new DateTime(2019, 5, 1), 31);
                yield return new TestCaseData(new DateTime(2019, 6, 1), 30);
                yield return new TestCaseData(new DateTime(2019, 7, 1), 31);
                yield return new TestCaseData(new DateTime(2019, 8, 1), 31);
                yield return new TestCaseData(new DateTime(2019, 9, 1), 30);
                yield return new TestCaseData(new DateTime(2019, 10, 1), 31);
                yield return new TestCaseData(new DateTime(2019, 11, 1), 30);
                yield return new TestCaseData(new DateTime(2019, 12, 1), 31);
                yield return new TestCaseData(new DateTime(2016, 2, 1), 29);
                yield return new TestCaseData(new DateTime(2020, 2, 1), 29);
            }
        }
    }
}
