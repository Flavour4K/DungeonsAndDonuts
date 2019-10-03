using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DungeonsandDonuts.Characters;
using DungeonsandDonuts.Effects;
using DungeonsandDonuts.Enemies;
using Newtonsoft.Json;

namespace DungeonsandDonuts.Settings
{
    public static class SettingsManager
    {
        /// <summary>
        /// Dictionary that contains all classes
        /// </summary>
        public static Dictionary<GameEnums.Character, Character> Classes { get; set; }

        public static Dictionary<GameEnums.Effect, Effect> Effects { get; set; }

        public static Dictionary<GameEnums.Enemies, Enemy> Enemies { get; set; }

        /// <summary>
        /// Loads all base classes of characters
        /// </summary>
        public static void LoadClasses()
        {
            //Get base path
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            //Build path to classes File
            var jsonPath = Path.Combine(basePath, "Settings", "Files", "Classes.json");

            var jsonClasses = File.ReadAllText(jsonPath);
            //Convert json to object
            Classes = JsonConvert.DeserializeObject<Dictionary<GameEnums.Character, Character>>(jsonClasses);
        }

        /// <summary>
        /// Loads all default effects
        /// </summary>
        public static void LoadEffects()
        {
            //Get base path
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            //Build path to classes File
            var jsonPath = Path.Combine(basePath, "Settings", "Files", "Effects.json");

            var jsonEffects = File.ReadAllText(jsonPath);
            //Convert json to object
            Effects = JsonConvert.DeserializeObject<Dictionary<GameEnums.Effect, Effect>>(jsonEffects);
        }

        public static void LoadEnemies()
        {
            //Get base path
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            //Build path to classes File
            var jsonPath = Path.Combine(basePath, "Settings", "Files", "Enemies.json");

            var jsonEnemies = File.ReadAllText(jsonPath);
            //Convert json to object
            Enemies = JsonConvert.DeserializeObject<Dictionary<GameEnums.Enemies, Enemy>>(jsonEnemies);
        }
    }
}
