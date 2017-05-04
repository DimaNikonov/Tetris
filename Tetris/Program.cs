using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 59;
            Console.WindowWidth = 48;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();
            GameEngine engine = new TetrisGameEngine(graphics);
            Field Field = new Field(graphics);
            Field.FillField();
            engine.Start(Field);
        }

        
    }
}
