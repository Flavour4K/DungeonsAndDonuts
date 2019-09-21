using System;
using System.Collections.Generic;
using System.Text;
using DungeonsandDonuts.Abilities;

namespace DungeonsandDonuts.Characters
{
    public class Character
    {
        public int HealthPoints { get; set; }
        public int ManaPoints { get; set; }
        //public int Exp { get; set; }
        //public int LvL { get; set; }

        public int ArmorValue { get; set; }
        public int MagicResistance { get; set; }
        public int AttackDamage { get; set; }
        public int AbilityPower { get; set; }
        public string GenderName { get; private set; }

        public bool Gender
        {
            set { GenderName = value ? "Male" : "Female"; }
        }

        public List<Ability> Abilities;

        public CharacterENUM.Character CharacterType { get; set; }




    }
}
