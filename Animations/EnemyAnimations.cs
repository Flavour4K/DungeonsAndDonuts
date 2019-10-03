using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsandDonuts.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonsandDonuts.Animations
{
    public static class EnemyAnimations
    {
        private static Dictionary<GameEnums.EnemyAnimation, List<Texture2D>> _animations;

        public static async void LoadAnimations(ContentManager manager)
        {
            await Task.Run(() =>
            {
                _animations = new Dictionary<GameEnums.EnemyAnimation, List<Texture2D>>();

                var list = new List<Texture2D>();
                for (var i = 1; i < 9; i++)
                {
                    list.Add(manager.Load<Texture2D>($"Enemies/Zombie/Male/Attack/Attack ({i})"));
                }
                _animations.Add(GameEnums.EnemyAnimation.Attacking, list);

                list = new List<Texture2D>();
                for (var i = 1; i < 13; i++)
                {
                    list.Add(manager.Load<Texture2D>($"Enemies/Zombie/Male/Dead/Dead ({i})"));
                }
                _animations.Add(GameEnums.EnemyAnimation.Dying, list);

                list = new List<Texture2D>();
                for (var i = 1; i < 16; i++)
                {
                    list.Add(manager.Load<Texture2D>($"Enemies/Zombie/Male/Idle/Idle ({i})"));
                }
                _animations.Add(GameEnums.EnemyAnimation.Idle, list);

                list = new List<Texture2D>();
                for (var i = 1; i < 11; i++)
                {
                    list.Add(manager.Load<Texture2D>($"Enemies/Zombie/Male/Walk/Walk ({i})"));
                }
                _animations.Add(GameEnums.EnemyAnimation.Walking, list);
            });
        }

        public static void Animate(this Enemy enemy, GameEnums.EnemyAnimation animation, SpriteBatch sprite, ref GraphicsDeviceManager gd, SpriteEffects effect, GameTime time)
        {
            if (_animations == null || !_animations.Any() || !_animations.ContainsKey(animation))
                return;

            if (time.TotalGameTime.TotalSeconds - enemy.GameTime > .05)
            {
                enemy.AnimationCounter++;
                if (enemy.AnimationCounter > _animations[animation].Count - 1)
                    enemy.AnimationCounter = 1;
                enemy.GameTime = time.TotalGameTime.TotalSeconds;
            }

            var animationPNGs = _animations[animation][enemy.AnimationCounter];


            sprite.Draw(
            animationPNGs,
            enemy.Position,
            null,
            Color.White,
            0f,
            new Vector2(animationPNGs.Width / 2, animationPNGs.Height / 2),
            0.3f,
            effect,
            0f
            );

            
        }

        public static void StopAnimation(this Enemy enemy)
        {
            enemy.AnimationCounter = 0;
        }
    }
}
