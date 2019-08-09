using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;
using System.Collections;

namespace ModaTime.Test
{
    class CompareTests
    {
        [Test, TestCaseSource("TestCases")]
        public void SourceDate_Later_TargetDate(DateTime source, DateTime target, TimeSpan timeSpan)
        {
            var actual = source.Compare(target);
            actual.Should().Be(timeSpan);
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 2), new DateTime(2019, 1, 1), TimeSpan.FromDays(1));
                yield return new TestCaseData(new DateTime(2019, 1, 1), new DateTime(2019, 1, 2), TimeSpan.FromDays(-1));
                yield return new TestCaseData(new DateTime(2019, 2, 1), new DateTime(2019, 1, 1), TimeSpan.FromDays(31));
                yield return new TestCaseData(new DateTime(2019, 3, 1), new DateTime(2019, 4, 1), TimeSpan.FromDays(-31));
            }
        }

        [Test, TestCaseSource("TestCases")]
        public void GetCompareTotalDays(DateTime source, DateTime target, TimeSpan timeSpan)
        {
            var actual = source.GetCompareTotalDays(target);
            actual.Should().Be(timeSpan.TotalDays);
        }
        [Test, TestCaseSource("TestCases_Hour")]
        public void GetCompareTotalHours(DateTime source, DateTime target, int hour)
        {
            var actual = source.GetCompareTotalHours(target);
            actual.Should().Be(hour);
        }

        public static IEnumerable TestCases_Hour
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 1, 3, 0, 0), new DateTime(2019, 1, 1, 1,0,0), 2);
                yield return new TestCaseData(new DateTime(2019, 1, 1, 0, 0, 0), new DateTime(2019, 1, 2, 0,0,0), -24);
                yield return new TestCaseData(new DateTime(2019, 1, 3, 0, 0, 0), new DateTime(2019, 1, 1, 0,0,0), 48);
                yield return new TestCaseData(new DateTime(2019, 1, 1, 1, 0, 0), new DateTime(2019, 1, 1, 1,0,0), 0);
            }
        }

        [Test, TestCaseSource("TestCases_Minute")]
        public void GetCompareTotalMinute(DateTime source, DateTime target, int minutes)
        {
            var actual = source.GetCompareTotalMinute(target);
            actual.Should().Be(minutes);
        }

        public static IEnumerable TestCases_Minute
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 1, 1, 0, 1, 0), new DateTime(2019, 1, 1, 0, 0, 0), 1);
                yield return new TestCaseData(new DateTime(2019, 3, 1, 0, 6, 0), new DateTime(2019, 3, 1, 0, 0, 0), 6);
                yield return new TestCaseData(new DateTime(2019, 4, 1, 1, 6, 0), new DateTime(2019, 4, 1, 0, 0, 0), 66);
                yield return new TestCaseData(new DateTime(2019, 7, 10, 0, 0, 0), new DateTime(2019, 7, 9, 0, 0, 0), 1440);
                yield return new TestCaseData(new DateTime(2019, 9, 20, 0, 0, 0), new DateTime(2019, 9, 21, 0, 0, 0), -1440);
                yield return new TestCaseData(new DateTime(2019, 11, 25, 0, 0, 0), new DateTime(2019, 11, 25, 8, 7, 0), -487);
            }
        }

        [Test, TestCaseSource("TestCases_Minute")]
        public void GetCompareTotalSecond(DateTime source, DateTime target, int minutes)
        {
            var actual = source.GetCompareTotalSecond(target);
            actual.Should().Be(minutes * 60);
        }

        [Test, TestCaseSource("TestCases_Minute")]
        public void GetCompareTotalMilliSecond(DateTime source, DateTime target, int minutes)
        {
            var actual = source.GetCompareTotalMilliseconds(target);
            actual.Should().Be(minutes * 60 * 1000);
        }
    }
}