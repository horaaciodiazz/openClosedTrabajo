using System;
using System.Linq;

namespace Ucu.Poo.Ocp
{
    /// <summary>
    /// Esta clase representa un calendario de días feriados. Por simplicidad no
    /// se consideran los días feriados de otros países ni los feriados
    /// laborables.
    /// </summary>
    public static class Calendar
    {
        // Lista de días feriados en formato "ddMM" para Uruguay.
        private static readonly string[] holidays = new string[]
        {
            "0101", // 1º de enero, Año Nuevo
            "0105", // 1º de mayo, Día de los Trabajadores
            "1807", // 18 de julio, Jura de la Constitución
            "2508", // 25 de agosto, Declaratoria de la Independencia
            "2512" // 25 de diciembre, Navidad
        };

        /// <summary>
        /// Determina si una fecha dada es un día feriado.
        /// </summary>
        /// <param name="date">La fecha a determinar si es feriado o no.</param>
        /// <returns>true si la fecha provista es feriado, false en caso
        /// contrario.</returns>
        public static bool IsHoliday(DateTime date)
        {
            return holidays.Contains($"{date.Day:00}{date.Month:00}");
        }
    }
}