using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonsandDonuts.Characters
{
    public static class CharacterManager
    {
        /// <summary>
        /// Divide any angle by this constant an you get the proper value for texture rotation
        /// </summary>
        private const float _rotationFactor = 57.14285714285714f;

        private static bool _hit;

        private static bool _mayHit = true;

        private static Timer _hitTimer;

        private static Timer _mayHitTimer;

        public static SpriteEffects Direction = SpriteEffects.None;

        public static void DrawMainCharacter(SpriteBatch batch, KeyboardState state, SpriteEffects effect)
        {
            var texture = GameManager.Character.IdleTexture;

            if (!CheckMainCharacterStoppedMoving(state) && CheckMainCharacterMoving())
                texture = GameManager.Character.RunningTexture;

            if (_hit)
                texture = GameManager.Character.BasicHitTexture;

            batch.Draw(
                texture,
                GameManager.Character.Position,
                null,
                Color.White,
                GameManager.Character.Rotation,
                new Vector2(GameManager.Character.IdleTexture.Width / 2, GameManager.Character.IdleTexture.Height / 2),
                1f,
                effect,
                0f
            );
        }
        
        public static void MoveMainCharacter(List<Keys> pressedKeys, GameTime time, GraphicsDeviceManager manager)
        {
            var elapsedTime = (float)time.ElapsedGameTime.TotalSeconds;

            Direction = SpriteEffects.None;

            if (pressedKeys.Contains(Keys.Down))
            {
                GameManager.Character.PositionY += GameManager.Character.Speed * elapsedTime;
                GameManager.Character.IsMoving.Remove(Keys.Down);
                GameManager.Character.IsMoving.Add(Keys.Down, true);
            }

            if (pressedKeys.Contains(Keys.Up))
            {
                GameManager.Character.PositionY -= GameManager.Character.Speed * elapsedTime;
                GameManager.Character.IsMoving.Remove(Keys.Up);
                GameManager.Character.IsMoving.Add(Keys.Up, true);
            }

            if (pressedKeys.Contains(Keys.Right))
            {
                GameManager.Character.PositionX += GameManager.Character.Speed * elapsedTime;
                GameManager.Character.IsMoving.Remove(Keys.Right);
                GameManager.Character.IsMoving.Add(Keys.Right, true);
            }


            if (pressedKeys.Contains(Keys.Left))
            {
                GameManager.Character.PositionX -= GameManager.Character.Speed * elapsedTime;
                GameManager.Character.IsMoving.Remove(Keys.Left);
                GameManager.Character.IsMoving.Add(Keys.Left, true);
                Direction = SpriteEffects.FlipHorizontally;
            }
                

            //so it cant escape :D
            GameManager.Character.PositionX = Math.Min(Math.Max(GameManager.Character.IdleTexture.Width / 2, GameManager.Character.Position.X), manager.PreferredBackBufferWidth - GameManager.Character.IdleTexture.Width / 2);
            GameManager.Character.PositionY = Math.Min(Math.Max(GameManager.Character.IdleTexture.Height / 2, GameManager.Character.Position.Y), manager.PreferredBackBufferHeight - GameManager.Character.IdleTexture.Height / 2);
        }

        public static bool CheckMainCharacterStoppedMoving(KeyboardState state)
        {
            if (!GameManager.Character.IsMoving.Any(a => a.Value))
                return false;

            if (GameManager.Character.IsMoving.Any(w => !state.IsKeyUp(w.Key)))
                return false;

            var edit = GameManager.Character.IsMoving.Where(keyValuePair => keyValuePair.Value).ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => false);

            foreach (var (key, value) in edit)
            {
                GameManager.Character.IsMoving.Remove(key);
                GameManager.Character.IsMoving.Add(key, value);
            }

            return true;
        }

        public static bool CheckMainCharacterMoving()
        {
            return GameManager.Character.IsMoving.Any(a => a.Value);
        }

        public static bool Hit(KeyboardState state)
        {
            if (!state.IsKeyDown(Keys.Space) || _hit || !_mayHit)
                return false;

            var attackSpeed = (int)(1000 / GameManager.Character.AttacksPerSecond);

            _hitTimer = new Timer(HitTimerTick, null, GameManager.Character.HitAnimationDurationMilliSecs, 0);
            _mayHitTimer = new Timer(MayHitTimerTick, null, attackSpeed, 0);
            _mayHit = false;
            _hit = true;
            return true;

        }

        private static void MayHitTimerTick(object arg)
        {
            _mayHit = true;
        }

        private static void HitTimerTick(object arg)
        {
            _hit = false;
            _hitTimer.Dispose();
        }
    }
}
