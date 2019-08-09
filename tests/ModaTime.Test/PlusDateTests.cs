using FluentAssertions;
using ModaTime;
using NUnit.Framework;
using System;

namespace JodaTimeLib.Test
{
    public class PlusDateTests
    {
        private DateTime _date;
        [SetUp]
        public void Setup()
        {
            _date = new DateTime(2019, 8, 7, 6, 5, 4, 321);
        }

        [Test]
        public void Get_Next_Year()
        {
            var actual = _date.PlusYears(1).Year;
            actual.Should().Be(_date.AddYears(1).Year);
        }

        [Test]
        public void Get_Last_Year()
        {
            var actual = _date.PlusYears(-1).Year;
            actual.Should().Be(_date.AddYears(-1).Year);
        }
        [Test]
        public void Get_Next_Month()
        {
            var actual = _date.PlusMonths(1).Month;
            actual.Should().Be(_date.AddMonths(1).Month);
        }

        [Test]
        public void Get_Last_Month()
        {
            var actual = _date.PlusMonths(-1).Month;
            actual.Should().Be(_date.AddMonths(-1).Month);
        }

        [Test]
        public void Get_Tomorrow()
        {
            var actual = _date.PlusDays(1).Day;
            actual.Should().Be(_date.AddDays(1).Day);
        }

        [Test]
        public void Get_Yesterday()
        {
            var actual = _date.PlusDays(-1).Day;
            actual.Should().Be(_date.AddDays(-1).Day);
        }

        [Test]
        public void Get_Next_Hour()
        {
            var actual = _date.PlusHours(1).Hour;
            actual.Should().Be(_date.AddHours(1).Hour);
        }

        [Test]
        public void Get_Last_Hour()
        {
            var actual = _date.PlusHours(-1).Hour;
            actual.Should().Be(_date.AddHours(-1).Hour);
        }

        [Test]
        public void Get_Next_Minute()
        {
            var actual = _date.PlusMinutes(1).Minute;
            actual.Should().Be(_date.AddMinutes(1).Minute);
        }

        [Test]
        public void Get_Last_Minute()
        {
            var actual = _date.PlusMinutes(-1).Minute;
            actual.Should().Be(_date.AddMinutes(-1).Minute);
        }

        [Test]
        public void Get_Next_Second()
        {
            var actual = _date.PlusSeconds(1);
            actual.Should().Be(_date.AddSeconds(1));
        }

        [Test]
        public void Get_Last_Second()
        {
            var actual = _date.PlusSeconds(-1).Second;
            actual.Should().Be(_date.AddSeconds(-1).Second);
        }

        [Test]
        public void Get_Next_MilliSecond()
        {
            var actual = _date.PlusMilliseconds(1).Millisecond;
            actual.Should().Be(_date.AddMilliseconds(1).Millisecond);
        }

        [Test]
        public void Get_Last_MilliSecond()
        {
            var actual = _date.PlusMilliseconds(-1).Millisecond;
            actual.Should().Be(_date.AddMilliseconds(-1).Millisecond);
        }
    }
}