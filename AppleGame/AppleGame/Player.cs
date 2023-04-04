using System.Numerics;
using Raylib_CsLo;

namespace AppleGame
{
    public class Player
    {
        public Vector2 position;
        public int width;
        public int height;
        public float speed;


        public Color color; // One of Raylib colors
        //public Vector2 velocity;

        // Constructor, creates a new player

        public Player(Vector2 position, int width, int height, Color color, float speed)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.color = color;
            //this.velocity = new Vector2(0, 0);
            this.speed = speed;
        }

        public Rectangle GetRectangle()
        {
            Rectangle r = new Rectangle(position.X, position.Y, height, width);
            return r;
        }

        // Update is called every frame
        public void Update(int screen_width, int screen_height)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.X += speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.X -= speed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.Y -= speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.Y += speed;
            }

            // Prevent player from going outside the window

            position.X = Math.Clamp(position.X, 0, screen_width - width);
            position.Y = Math.Clamp(position.Y, 0, screen_height - height);
        }


        // Draw is called after Update()
        public void Draw()
        {
            // Rectangle is defined by 4 integers,
            // we need to cast from float to int using (int) like in Python
            Raylib.DrawRectangle((int)this.position.X, (int)this.position.Y, width, height, color);
        }
    }
}