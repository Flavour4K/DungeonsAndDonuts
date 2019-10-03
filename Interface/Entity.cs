using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonsandDonuts.Interface
{
    public class Entity
    {
        public Texture2D Texture { get; set; }

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
