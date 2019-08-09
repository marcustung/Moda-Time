using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;

namespace ModaTime.Test
{
    class IsAfterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, TestCaseSource("Diffdate_TestCases_returnTrue")]
        public void SourceDate_Later_TargetDate(DateTime source, DateTime target)
        {
            var actual = source.IsAfter(target);
            actual.Should().BeTrue();
        }

        public static IEnumerable Diffdate_TestCases_returnTrue
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 5), new DateTime(2019, 1, 1));
                yield return new TestCaseData(new DateTime(2019, 2, 6), new DateTime(2019, 2, 2));
                yield return new TestCaseData(new DateTime(2019, 3, 7), new DateTime(2019, 3, 3));
                yield return new TestCaseData(new DateTime(2019, 4, 8), new DateTime(2019, 4, 4));
                yield return new TestCaseData(new DateTime(2019, 5, 9), new DateTime(2019, 5, 5));
                yield return new TestCaseData(new DateTime(2020, 6, 10), new DateTime(2019, 6, 6));
            }
        }

        [Test, TestCaseSource("Diffdate_TestCases_returnFalse")]
        public void SourceDate_Earlier_TargetDate(DateTime source, DateTime target)
        {
            var actual = source.IsAfter(target);
            actual.Should().BeFalse();
        }

        public static IEnumerable Diffdate_TestCases_returnFalse
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 7, 1), new DateTime(2019, 7, 7));
                yield return new TestCaseData(new DateTime(2019, 8, 1), new DateTime(2019, 8, 8));
                yield return new TestCaseData(new DateTime(2019, 9, 1), new DateTime(2019, 9, 9));
                yield return new TestCaseData(new DateTime(2019, 10, 1), new DateTime(2019, 10, 10));
                yield return new TestCaseData(new DateTime(2019, 11, 1), new DateTime(2019, 11, 11));
                yield return new TestCaseData(new DateTime(2019, 12, 1), new DateTime(2019, 12, 12));
            }
        }

        [Test, TestCaseSource("Samedate_TestCases")]
        public void SameDate(DateTime source, DateTime target)
        {
            var actual = source.IsAfter(target);
            actual.Should().BeFalse();
        }

        public static IEnumerable Samedate_TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 7, 1), new DateTime(2019, 7, 1));
                yield return new TestCaseData(new DateTime(2019, 8, 1), new DateTime(2019, 8, 1));
                yield return new TestCaseData(new DateTime(2019, 9, 1), new DateTime(2019, 9, 1));
                yield return new TestCaseData(new DateTime(2019, 10, 1), new DateTime(2019, 10, 1));
                yield return new TestCaseData(new DateTime(2019, 11, 1), new DateTime(2019, 11, 1));
                yield return new TestCaseData(new DateTime(2019, 12, 1), new DateTime(2019, 12, 1));
            }
        }
    }
}
