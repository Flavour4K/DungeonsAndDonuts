using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsandDonuts
{
    public static class GameEnums
    {
        public enum Effect
        {
            Ignite,
            Heal
        }

        public enum Character
        {
            Knight,
            Wizard
        }

        public enum UiElements
        {
            AbilityBorder
        }

        public enum Enemies
        {
            Zombie
        }

        public enum EnemyAnimation
        {
            Idle,
            Walking,
            Attacking,
            Dying
        }
    }
}
