using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DungeonsandDonuts.Abilities;
using DungeonsandDonuts.Animations;
using DungeonsandDonuts.Characters;
using DungeonsandDonuts.Enemies;
using DungeonsandDonuts.Interface;
using DungeonsandDonuts.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonsandDonuts
{
    public static class GameManager
    {
        
        public static RenderContext Render { get; set; }
        public static Character Character { get; set; }

        public static List<Enemy> Enemies { get; set; }

        public static Dictionary<GameEnums.UiElements, Entity> UiElements { get; set; }

        public static Dictionary<GameEnums.UiElements, Entity> Obstacles { get; set; }

        public static void CreateCharacter(GameEnums.Character type, ref GraphicsDeviceManager manager)
        {
            Character = SettingsManager.Classes[type];
            Character.Rotation = 0;
            Character.Position = new Vector2(manager.PreferredBackBufferWidth / 2,
                manager.PreferredBackBufferHeight / 2);
            Character.IsMoving.Add(Keys.Down, false);
            Character.IsMoving.Add(Keys.Up, false);
            Character.IsMoving.Add(Keys.Left, false);
            Character.IsMoving.Add(Keys.Right, false);
            Character.Gender = true;
        }

        public static void AddAnemy(GameEnums.Enemies type, ref GraphicsDeviceManager manager, int count, Random rnd)
        {
            for (var i = 0; i < count; i++)
            {
                var wid = rnd.Next(50, manager.PreferredBackBufferWidth / 2 - 50);
                var heig = rnd.Next(50, manager.PreferredBackBufferHeight / 2 - 50);
                var enemy = SettingsManager.Enemies[type];
                var enemyToAdd = new Enemy
                {
                    AnimationCounter = enemy.AnimationCounter,
                    AttacksPerSecond = enemy.AttacksPerSecond,
                    AbilityPower = enemy.AbilityPower,
                    ArmorValue = enemy.ArmorValue,
                    AttackDamage = enemy.AttackDamage,
                    EnemyType = enemy.EnemyType,
                    HealthPoints = enemy.HealthPoints,
                    MovementSpeed = enemy.MovementSpeed,
                    MagicResistance = enemy.MagicResistance,
                    ManaPoints = enemy.ManaPoints
                };
                enemyToAdd.Position = new Vector2(wid, heig);
                Enemies.Add(enemyToAdd);
            }
            
        }

        public static void LoadSettings(ContentManager content)
        {
            EnemyAnimations.LoadAnimations(content);
            SettingsManager.LoadClasses();
            SettingsManager.LoadEffects();
            SettingsManager.LoadEnemies();
        }

        /// <summary>
        /// Sets window size
        /// </summary>
        public static void SetupWindow(ref GraphicsDeviceManager manager, GraphicsDevice device)
        {
            Enemies = new List<Enemy>();
            manager.PreferredBackBufferWidth = 1133;
            manager.PreferredBackBufferHeight = 840;
            manager.ApplyChanges();
        }

        public static void LoadUiElements(ContentManager content, GraphicsDevice device)
        {
            UiElements = new Dictionary<GameEnums.UiElements, Entity>();
            //foreach (var type in Enum.GetValues(typeof(GameEnums.UiElements)))
            //{
            //    var element = new Entity
            //    {
            //        PositionX = 30,
            //        PositionY = device.DisplayMode.Height - 100,
            //        Texture = content.Load<Texture2D>("interface/ability-border")
            //    };
            //    UiElements.Add((GameEnums.UiElements)type, element);
            //}
        }

        public static Texture2D LoadIdleContent(ContentManager content, GameEnums.Character character)
        {
            var gender = Character.GenderName;
            switch (character)
            {
                case GameEnums.Character.Knight:
                    return content.Load<Texture2D>("knight");
                case GameEnums.Character.Wizard:
                    return content.Load<Texture2D>($"wizard-{gender}");
                default:
                    return null;
            }
        }

        public static Texture2D LoadRunningContent(ContentManager content, GameEnums.Character character)
        {
            var gender = Character.GenderName;
            switch (character)
            {
                case GameEnums.Character.Knight:
                    return content.Load<Texture2D>("knight-running");
                case GameEnums.Character.Wizard:
                    return content.Load<Texture2D>($"wizard-{gender}-running");
                default:
                    return null;
            }
        }

        public static Texture2D LoadBasicHitContent(ContentManager content, GameEnums.Character character)
        {
            var gender = Character.GenderName;
            switch (character)
            {
                case GameEnums.Character.Knight:
                    return content.Load<Texture2D>("knight-basichit");
                case GameEnums.Character.Wizard:
                    return content.Load<Texture2D>($"wizard-{gender}-basichit");
                default:
                    return null;
            }
        }
    }

}
