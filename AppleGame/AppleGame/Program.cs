using AppleGame;
using Raylib_CsLo;
//using System.Drawing;
using System.Numerics;

namespace AppleGame
{
    class Program
    {
        
        public static void Main()
        {
            AppleGameTest test = new AppleGameTest();
            test.Run();
        }

    }
    class AppleGameTest
    {
        const int screen_width = 900;
        const int screen_height = 720;
        public AppleGameTest()
        {

        }

        public void Run()
        {
            Raylib.InitWindow(screen_width, screen_height, "Raylib");
            Raylib.SetTargetFPS(60);   
            Player player = new Player(new Vector2(), 50, 50, Raylib.GOLD, 5);
            Apple apple = new Apple(new Vector2(), 25, 25, Raylib.GREEN);

            Random changePos = new Random();
            apple.position.X = changePos.Next(0, screen_width);
            apple.position.Y = changePos.Next(0, screen_height);

            while (Raylib.WindowShouldClose() == false)
            {
                
                Update(player);
                //Color bgColor = Raylib.DARKGRAY;
                Rectangle playerRect = player.GetRectangle();
                if (Raylib.CheckCollisionRecs(playerRect, apple.GetRectangle()))
                {
                    apple.position.X = changePos.Next(0, screen_width);
                    apple.position.Y = changePos.Next(0, screen_height);
                }
                Draw(player, apple);
            }

            Raylib.CloseWindow();
        }

        private void Draw(Player player, Apple apple)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.BLACK);
            player.Draw();
            apple.Draw();
            Raylib.EndDrawing();
        }

        private void Update(Player player)
        {
            player.Update(screen_width, screen_height);
        }
    }
}