using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsandDonuts.Abilities
{
    public class Ability
    {
        public double HealScaling { get; set; }

        public Action HealScalingAction;

        public double AttackScaling { get; set; }

        public Action AttackScalingAction { get; set; }


    }
}
