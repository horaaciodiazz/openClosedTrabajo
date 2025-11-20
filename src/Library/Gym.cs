using System;

namespace Ucu.Poo.Ocp
{
    public class Gym
    {
        public bool CanEnter(IAccess membership, DateTime date, int hour)
        {
            return membership.IsAllowed(date, hour);
        }
    }
}