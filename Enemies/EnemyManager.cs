using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsandDonuts.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonsandDonuts.Enemies
{
    public static class EnemyManager
    {
        public static void DrawEnemies(ref GraphicsDeviceManager gd, SpriteBatch sprite, GameTime time)
        {
            foreach (var enemy in GameManager.Enemies)
            {
                enemy.Animate(enemy.CurrentAnimation, sprite, ref gd, SpriteEffects.None, time);
            }
        }

        public static void MoveEnemies(GameTime time)
        {
            var mainChar = GameManager.Character;
            var enemiesToDelete = new List<Enemy>();
            foreach (var enemy in GameManager.Enemies)
            {
                if (enemy.IsDying)
                    continue;

                if (enemy.HealthPoints <= 0 && !enemy.IsDying)
                {
                    enemiesToDelete.Add(enemy);
                    continue;
                }

                if (enemy.CanAttack(mainChar))
                    continue;

                if (enemy.CurrentAnimation != GameEnums.EnemyAnimation.Walking)
                {
                    enemy.StopAnimation();
                    enemy.CurrentAnimation = GameEnums.EnemyAnimation.Walking;
                }

                var dir = mainChar.Position - enemy.Position;
                dir.Normalize();
                enemy.Direction = dir*12/10;

                enemy.Position += enemy.Direction;
            }

            if (enemiesToDelete.Any())
                EnemyDead();
        }

        private static void EnemyDead()
        {

        }
    }
}
