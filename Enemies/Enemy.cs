using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DungeonsandDonuts.Effects;

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

        public int ArmorValue { get; set; }
        public int MagicResistance { get; set; }

        private List<EffectManager> _effectHandling = new List<EffectManager>();

        private List<Timer> _effectTimer = new List<Timer>();

        private Enemy _instance;

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

    }
}
