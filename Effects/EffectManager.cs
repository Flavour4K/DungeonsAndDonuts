using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DungeonsandDonuts.Enemies;

namespace DungeonsandDonuts.Effects
{
    public class EffectManager : IDisposable
    {
        private Timer _timer;
        public bool IsEffectDone { get; private set; }
        private Effect _effect;
        private Enemy _enemy;
        private int _maxTicks;
        private int _currentTick;

        /// <summary>
        /// Creates timer and starts the effects
        /// </summary>
        public void StartEffect(ref Enemy enemy, Effect effect)
        { //TODO: Eigene Timer klasse wo man ref objects übergeben kann
            _effect = effect;
            _enemy = enemy;
            _maxTicks = (int)(effect.DurationInSeconds / effect.TickIntervalSeconds);
            _maxTicks = _maxTicks == 0 ? 1 : _maxTicks;

            _timer = new Timer(
                ApplyEffect, 
                null, 
                new TimeSpan(0,0,0,0), 
                new TimeSpan(0, 0, 0, 0, (int)effect.TickIntervalSeconds*1000)
                );
        }

        private void ApplyEffect(object arg)
        {
            _currentTick++;
            if (_currentTick > _maxTicks)
            {
                IsEffectDone = true;
                _timer.Dispose();
                return;
            }

            var movementImpact = _effect.MovementSpeedInterference;
            var healthImpact = _effect.Healing;
            _enemy.HealthPoints += healthImpact;
            _enemy.MovementSpeed += movementImpact;
        }

        public void Dispose()
        {
            _timer.Dispose();
            _enemy = null;
            _effect = null;
        }
    }
}
