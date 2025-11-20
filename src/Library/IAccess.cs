using System;

namespace Ucu.Poo.Ocp
{
    public interface IAccess
    {
        // Devuelve true si la regla permite el acceso, false si no aplica o no permite
        bool IsAllowed(DateTime date, int hour);
    }
}