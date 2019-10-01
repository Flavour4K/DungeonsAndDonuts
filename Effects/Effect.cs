using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsandDonuts.Effects
{
    public class Effect
    {
        public double DurationInSeconds { get; set; }

        public double TickIntervalSeconds { get; set; }

        /// <summary>
        /// Negative value if its supposed to deal damage
        /// </summary>
        public double Healing { get; set; }

        /// <summary>
        /// Negative if slow, Positive if speed up
        /// </summary>
        public double MovementSpeedInterference { get; set; }
    }
}
