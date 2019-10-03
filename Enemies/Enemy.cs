using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DungeonsandDonuts.Characters;
using DungeonsandDonuts.Effects;
using Microsoft.Xna.Framework;

namespace DungeonsandDonuts.Enemies
{
    public class Enemy
    {
        public Enemy()
        {
            _instance = this;
        }

        public double HealthPoints { get; set; }
        public int ManaPoints { get; set; }
        //public int LvL { get; set; }
        public double MovementSpeed { get; set; }

        public bool IsDying { get; set; }

        public int ArmorValue { get; set; }

        public double AttacksPerSecond { get; set; }

        public double AbilityPower { get; set; }

        public double AttackDamage { get; set; }

        public float AttackRange { get; set; } = 30;

        public Vector2 Direction { get; set; }

        public double GameTime { get; set; }
        public int MagicResistance { get; set; }

        private List<EffectManager> _effectHandling = new List<EffectManager>();

        private List<Timer> _effectTimer = new List<Timer>();

        private Enemy _instance;

        public GameEnums.Enemies EnemyType { get; set; }

        public GameEnums.EnemyAnimation CurrentAnimation { get; set; } = GameEnums.EnemyAnimation.Idle;

        public int AnimationCounter { get; set; } = 50;

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

        public void ApplyEffect(GameEnums.Effect effect)
        {
            var effett = new Effects.Effect();

            var handle = new EffectManager();

            handle.StartEffect(ref _instance, effett);

            _effectHandling.Add(handle);
        }

        private void ApplyBurn()
        {

        }

        public bool CanAttack(Character character)
        {
            var halfHitBoxX = character.Hitbox.X / 2;
            var halfHitBoxY = character.Hitbox.Y / 2;
            var right = character.PositionX + halfHitBoxX;
            var left = character.PositionX - halfHitBoxX;
            var down = character.PositionY + halfHitBoxY;
            var top = character.PositionY - halfHitBoxY;

            var dist = Math.Abs(character.Position.Length() - Position.Length());
            if (dist < AttackRange)
                return true;

            return false;
        }
    }
}
