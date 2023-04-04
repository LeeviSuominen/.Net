using Raylib_CsLo;
using raylib_testi;
using System.Drawing;

namespace raylib_pohja
{
    class Program
    {
        
        public static void Main()
        {
            WindowTest test = new WindowTest();
            test.Run();
        }

    }

    class WindowTest
    {
        const int screen_width = 720;
        const int screen_height = 430;
        public WindowTest()
        {

        }

        public void Run()
        {
            Raylib.InitWindow(screen_width, screen_height, "Raylib");
            Raylib.SetTargetFPS(60);

            while (Raylib.WindowShouldClose() == false)
            {
                Update();
                Draw();
            }

            Raylib.CloseWindow();
        }

        private void Draw()
        {
            ChessBoard board = new ChessBoard();
            Raylib.BeginDrawing();
            board.Draw(40, 30, 30);
            Raylib.EndDrawing();
        }

        private void Update()
        {
            // Update game here
        }
    }
        
}