using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonsandDonuts.Interface
{
    public static class InterfaceManager
    {
        public static Random _rnd = new Random();

        public static void DrawBackground(SpriteBatch sprite, ref GraphicsDeviceManager gd, Texture2D background, Texture2D obstacle)
        {
            sprite.Draw(
                background,
                new Vector2(gd.PreferredBackBufferWidth / 2, gd.PreferredBackBufferHeight / 2),
                null,
                Color.White,
                0f,
                new Vector2(background.Width / 2, background.Height / 2),
                1f,
                SpriteEffects.None,
                0f);

        }
    }
}
