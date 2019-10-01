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
        public double HealthInterference { get; set; }

        /// <summary>
        /// Negative if slow, Positive if speed up
        /// </summary>
        public double MovementSpeedInterference { get; set; }

        /// <summary>
        /// Maybe to show animations
        /// </summary>
        public GameEnums.Effect EffectType { get; set; }

        public bool IsTemporary { get; set; }
    }
}
