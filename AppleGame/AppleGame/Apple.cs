using Raylib_CsLo;
using System.Numerics;

namespace AppleGame
{
    internal class Apple
    {
        public Vector2 position;
        public int width;
        public int height;
        public Color color;

        public Apple(Vector2 position, int width, int height, Color color)
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