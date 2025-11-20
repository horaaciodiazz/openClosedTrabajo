using System;
using NUnit.Framework;
using Ucu.Poo.Ocp;

namespace Ucu.Poo.Ocp.Tests
{
    [TestFixture]
    public class CalendarNUnitAssertThatTests
    {
        [Test]
        public void NewYear_IsHoliday()
        {
            var date = new DateTime(2025, 1, 1);
            Assert.That(Calendar.IsHoliday(date), Is.True);
        }

        [Test]
        public void LaborDay_IsHoliday()
        {
            var date = new DateTime(2025, 5, 1);
            Assert.That(Calendar.IsHoliday(date), Is.True);
        }

        [Test]
        public void ConstitutionDay_IsHoliday()
        {
            var date = new DateTime(2025, 7, 18);
            Assert.That(Calendar.IsHoliday(date), Is.True);
        }

        [Test]
        public void IndependenceDay_IsHoliday()
        {
            var date = new DateTime(2025, 8, 25);
            Assert.That(Calendar.IsHoliday(date), Is.True);
        }

        [Test]
        public void Christmas_IsHoliday()
        {
            var date = new DateTime(2025, 12, 25);
            Assert.That(Calendar.IsHoliday(date), Is.True);
        }

        [TestCase(12, 31)]
        [TestCase(1, 2)]
        [TestCase(4, 30)]
        [TestCase(5, 2)]
        [TestCase(7, 17)]
        [TestCase(7, 19)]
        [TestCase(8, 24)]
        [TestCase(8, 26)]
        [TestCase(12, 24)]
        [TestCase(12, 26)]
        public void OtherDates_AreNotHoliday(int month, int day)
        {
            var date = new DateTime(2025, month, day);
            Assert.That(Calendar.IsHoliday(date), Is.False);
        }
    }
}
