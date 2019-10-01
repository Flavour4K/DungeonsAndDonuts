using System;
using System.Collections.Generic;
using System.Text;
using DungeonsandDonuts.Abilities;
using DungeonsandDonuts.Characters;
using DungeonsandDonuts.Settings;

namespace DungeonsandDonuts
{
    public static class GameHelper
    {
        public static Character Character { get; set; }

        public static void CreateCharacter(CharacterENUM.Character type)
        {
        }

        public static void LoadSettings()
        {
            SettingsManager.LoadClasses();
        }
    }

}
