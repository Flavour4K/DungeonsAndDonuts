using System;
using System.Collections.Generic;
using System.Text;
using DungeonsandDonuts.Abilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonsandDonuts.Characters
{
    public class Character
    {
        public int HealthPoints { get; set; }
        public int ManaPoints { get; set; }
        //public int Exp { get; set; }
        //public int LvL { get; set; }

        public int ArmorValue { get; set; }

        public Vector2 Hitbox { get; set; } = new Vector2(20, 20);
        public int MagicResistance { get; set; }

        public double AttacksPerSecond { get; set; }
        public int AttackDamage { get; set; }
        public int AbilityPower { get; set; }
        public string GenderName { get; private set; }

        public bool Gender
        {
            set { GenderName = value ? "Male" : "Female"; }
        }

        public List<Ability> Abilities;

        public GameEnums.Character CharacterType { get; set; }

        public float Rotation { get; set; }

        public Texture2D IdleTexture { get; set; }

        public Texture2D RunningTexture { get; set; }

        public Texture2D BasicHitTexture { get; set; }

        public Dictionary<Keys, bool> IsMoving { get; set; } = new Dictionary<Keys, bool>();

        public int HitAnimationDurationMilliSecs { get; set; }

        public float Speed { get; set; }


        //--------------------------------------------------------------------------

        //required for proper position handling
        private Vector2 _position;


        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public float PositionX
        {
            get => _position.X;
            set => _position.X = value;
        }

        public float PositionY
        {
            get => _position.Y;
            set => _position.Y = value;
        }
    }
}
