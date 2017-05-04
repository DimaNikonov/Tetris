using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
     class Field : GameObject
    {
        public struct Rectangle
        {
            public Color Color { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public byte CelsValue { get; set; } 
        }
        public const int size = 25;
        public Rectangle[,] Rectangles  = new Rectangle[28, 12];
        ConsoleGraphics graphics;

        public void FillField()
        {
            for (int i = 0; i < Rectangles.GetLength(0); i++)
            {
                for (int j = 0; j < Rectangles.GetLength(1); j++)
                {
                    Rectangles[i, j].CelsValue = 0;
                    Rectangles[i, j].Color = Color.DEfaultColoor;
                }
            }
        }

        public Field(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public override void Update(Field Field)
        {
            ;
        }
        public override void Render(ConsoleGraphics graphics)
        {
            foreach (var item in Rectangles)
            {
                graphics.FillRectangle((uint)item.Color, item.x,item.y, size, size);
            }
        }
    }
}
