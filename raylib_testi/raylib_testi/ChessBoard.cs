using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_CsLo;

namespace raylib_testi
{
    internal class ChessBoard
    {
        public ChessBoard() 
        {

        }

        public void Draw(int size, int start_x, int start_y)
        {
            Raylib.ClearBackground(Raylib.DARKGRAY);
            string letters = "abcdefgh";

            int columns = 8;
            //int size = 40;
            int rows = 8;

            Color[] colors = new Color[] {Raylib.BROWN, Raylib.WHITE};

            //int start_x = 30;
            //int start_y = 30;
            int colorOffset = 0;
            for (int r = 0; r < rows; r++)
            {
                int y = start_y + r * size;
                Raylib.DrawText((1 + r).ToString(), 12, y + size / 2, 20, Raylib.BLACK);
                for (int c = 0; c < columns; c++)
                {
                    int x = start_x + c * size;
                    if(r == 0)
                    {
                        Raylib.DrawText(letters[c].ToString(), x + size/2, start_y - size / 2, 20, Raylib.BLACK);
                    }
                    Raylib.DrawRectangle(x, y, size, size, colors[(c + r) % 2]);
                    Raylib.DrawRectangleLines(x, y, size, size, Raylib.BLACK);
                }
                colorOffset++;
            }
        }
    }
}
