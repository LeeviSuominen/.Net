using Raylib_CsLo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AppleGame
{
    internal class SpriteRenderer
    {
        public Vector2 position;
        public int width;
        public int height;
        public Color color;
        public SpriteRenderer(Vector2 position, int width, int height, Color color)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.color = color;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(position.X, position.Y, width, height);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(GetRectangle(), color);
        }
    }
}

