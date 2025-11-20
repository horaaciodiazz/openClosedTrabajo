using System;
using NUnit.Framework;
using Ucu.Poo.Ocp;

namespace Ucu.Poo.Ocp.Tests
{
    [TestFixture]
    public class GymTests
    {
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            gym = new Gym();
        }

        // Lunes a viernes 6am a 10am: Solo los usuarios que tengan membresía
        // premium pueden ingresar

        [Test]
        public void WeekdayEarly_Premium_Allowed()
        {
            var date = new DateTime(2025, 11, 17); // Monday
            Assert.That(gym.CanEnter(Membership.Premium, date, 6), Is.True);
            Assert.That(gym.CanEnter(Membership.Premium, date, 9), Is.True);
        }

        [Test]
        public void WeekdayEarly_BasicAndDayPass_Denied()
        {
            var date = new DateTime(2025, 11, 18); // Tuesday
            Assert.That(gym.CanEnter(Membership.Basic, date, 6), Is.False);
            Assert.That(gym.CanEnter(Membership.DayPass, date, 9), Is.False);
        }

        // Lunes a viernes 10am a 5pm: Pueden ingresar todos los usuarios con
        // cualquier membresía

        [Test]
        public void WeekdayDay_AllMemberships_Allowed()
        {
            var date = new DateTime(2025, 11, 20); // Thursday
            Assert.That(gym.CanEnter(Membership.Premium, date, 10), Is.True);
            Assert.That(gym.CanEnter(Membership.Basic, date, 12), Is.True);
            Assert.That(gym.CanEnter(Membership.DayPass, date, 16), Is.True);
        }

        // Lunes a viernes 5pm a 9pm: Sólo los usuarios con membresía básica o
        // premium pueden ingresar, los pases por el día no.
        [Test]
        public void WeekdayPeak_PremiumAndBasic_Allowed_DayPass_Denied()
        {
            var date = new DateTime(2025, 11, 18); // Tuesday
            Assert.That(gym.CanEnter(Membership.Premium, date, 18), Is.True);
            Assert.That(gym.CanEnter(Membership.Basic, date, 20), Is.True);
            Assert.That(gym.CanEnter(Membership.DayPass, date, 19), Is.False);
        }

        // Sábados: Pueden ingresar todos los usuarios con cualquier membresía
        // de 8am a 8pm.
        [Test]
        public void Saturday_PremiumAndBasic_Allowed()
        {
            var date = new DateTime(2025, 11, 22); // Saturday
            Assert.That(gym.CanEnter(Membership.Premium, date, 8), Is.True);
            Assert.That(gym.CanEnter(Membership.Basic, date, 19), Is.True);
        }

        [Test]
        public void Saturday_DayPass_Denied()
        {
            var date = new DateTime(2025, 11, 22); // Saturday
            Assert.That(gym.CanEnter(Membership.DayPass, date, 10), Is.False);
        }

        // Domingo: cerrado
        [Test]
        public void Sunday_NoOneAllowed()
        {
            var date = new DateTime(2025, 11, 23); // Sunday
            Assert.That(gym.CanEnter(Membership.Premium, date, 10), Is.False);
            Assert.That(gym.CanEnter(Membership.Basic, date, 10), Is.False);
            Assert.That(gym.CanEnter(Membership.DayPass, date, 10), Is.False);
        }

        // Horas fuera de rango habituales, antes de apertura y después de cierre
        [Test]
        public void OffHours_Weekday_BeforeOpening_Denied()
        {
            var date = new DateTime(2025, 11, 18); // Tuesday
            Assert.That(gym.CanEnter(Membership.Premium, date, 5), Is.False);
            Assert.That(gym.CanEnter(Membership.Basic, date, 5), Is.False);
            Assert.That(gym.CanEnter(Membership.DayPass, date, 5), Is.False);
        }

        [Test]
        public void OffHours_Weekday_AfterClosing_Denied()
        {
            var date = new DateTime(2025, 11, 20); // Thursday
            Assert.That(gym.CanEnter(Membership.Premium, date, 22), Is.False);
            Assert.That(gym.CanEnter(Membership.Basic, date, 22), Is.False);
            Assert.That(gym.CanEnter(Membership.DayPass, date, 22), Is.False);
        }

        // Pruebas adicionales por cada día laboral para asegurar 100% de
        // cobertura

        [Test]
        public void MondayCoverage_BasicDayPassRules()
        {
            var date = new DateTime(2025, 11, 17); // Monday
            Assert.That(gym.CanEnter(Membership.Basic, date, 9), Is.False);  // early not allowed
            Assert.That(gym.CanEnter(Membership.DayPass, date, 11), Is.True); // day allowed
            Assert.That(gym.CanEnter(Membership.DayPass, date, 18), Is.False); // peak not allowed
        }

        [Test]
        public void TuesdayCoverage_PremiumEarlyAllowed()
        {
            var date = new DateTime(2025, 11, 18); // Tuesday
            Assert.That(gym.CanEnter(Membership.Premium, date, 6), Is.True);
        }

        [Test]
        public void WednesdayCoverage_PeakBasicAllowed()
        {
            var date = new DateTime(2025, 11, 19); // Wednesday
            Assert.That(gym.CanEnter(Membership.Basic, date, 17), Is.True);
        }

        [Test]
        public void ThursdayCoverage_DayPassDayAllowed()
        {
            var date = new DateTime(2025, 11, 20); // Thursday
            Assert.That(gym.CanEnter(Membership.DayPass, date, 12), Is.True);
        }

        [Test]
        public void FridayCoverage_PeakDayPassDenied()
        {
            var date = new DateTime(2025, 11, 21); // Friday
            Assert.That(gym.CanEnter(Membership.DayPass, date, 19), Is.False);
        }
    }
}
