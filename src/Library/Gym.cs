using System;

namespace Ucu.Poo.Ocp
{
    /// <summary>
    /// Esta clase representa un gimnasio con reglas de acceso basadas en el
    /// tipo de usuario, día de la semana y hora del día.
    /// </summary>
    public class Gym
    {
        /// <summary>
        /// Determina si un usuario puede ingresar al gimnasio en un día y hora.
        /// </summary>
        /// <param name="membership"></param>
        /// <param name="date"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool CanEnter(Membership membership, DateTime date, int hour)
        {
            DayOfWeek dayOfWeek = date.DayOfWeek;

            // De lunes a viernes temprano en la mañana
            if ((dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Tuesday ||
                dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Thursday ||
                dayOfWeek == DayOfWeek.Friday) && hour >= 6 && hour < 10)
            {
                if (membership == Membership.Premium)
                {
                    return true;
                }

                return false;
            }

            // De lunes a viernes durante el día antes de la hora pico
            if ((dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Tuesday ||
                dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Thursday ||
                dayOfWeek == DayOfWeek.Friday) && hour >= 10 && hour < 17)
            {
                if (membership == Membership.Premium ||
                    membership == Membership.Basic ||
                    membership == Membership.DayPass)
                {
                    return true;
                }

                return false;
            }

            // De lunes a viernes en hora pico
            if ((dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Tuesday ||
                dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Thursday ||
                dayOfWeek == DayOfWeek.Friday) && hour >= 17 && hour < 21)
            {
                if (membership == Membership.Premium || membership == Membership.Basic)
                {
                    return true;
                }

                return false;
            }

            // Sábados
            if (dayOfWeek == DayOfWeek.Saturday && hour >= 8 && hour < 20)
            {
                if (membership == Membership.Premium || membership == Membership.Basic)
                {
                    return true;
                }

                return false;
            }

            // Domingos
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            return false;
        }
    }
}
