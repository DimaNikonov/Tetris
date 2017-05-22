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
            Console.SetWindowPosition(0, 0);
            Console.WindowHeight = 34;
            Console.WindowWidth = 48;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();
            //Console.WriteLine(graphics.ClientHeight);
            //Console.WriteLine(graphics.ClientWidth);
            GameEngine engine = new TetrisGameEngine(graphics);
            Field Field = new Field(graphics);
            Field.FillField(graphics);
            engine.Start(Field, engine);
            graphics.FillRectangle(0xFFFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
            graphics.FlipPages();
            Console.WriteLine("game is over");
            Console.ReadLine();
        }
    }
}
