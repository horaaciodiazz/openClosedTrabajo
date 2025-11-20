using System;

namespace Ucu.Poo.Ocp
{
    public class DayMembership : IAccess
    {
        public bool IsAllowed(DateTime date, int hour)
        {
            DayOfWeek day = date.DayOfWeek;
            bool isWeekDay = day >= DayOfWeek.Monday && day <= DayOfWeek.Friday;

            
            if (isWeekDay && hour >= 10 && hour < 17) return true;

            return false;
        }
    }
}