using System;

namespace Ucu.Poo.Ocp
{
    public class PremiumMembership : IAccess
    {
        public bool IsAllowed(DateTime date, int hour)
        {
            DayOfWeek day = date.DayOfWeek;
            bool isWeekDay = day >= DayOfWeek.Monday && day <= DayOfWeek.Friday;
            
            if (isWeekDay && hour >= 6 && hour < 21) return true;
            
            if (day == DayOfWeek.Saturday && hour >= 8 && hour < 20) return true; 
            return false;
        }
    }
}