using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DungeonsandDonuts.Characters;
using Newtonsoft.Json;

namespace DungeonsandDonuts.Settings
{
    public static class SettingsManager
    {
        /// <summary>
        /// Dictionary that contains all classes
        /// </summary>
        public static Dictionary<CharacterENUM.Character, object> Classes { get; set; }

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
            Classes = JsonConvert.DeserializeObject<Dictionary<CharacterENUM.Character, object>>(jsonClasses);
        }
    }
}
