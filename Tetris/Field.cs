using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace Tetris
{
    class Field
    {
        ConsoleGraphics graphics;
        public struct Rectangle
        {
            public Color Color { get; set; }
            public int x { get; set; }
            public int y { get; set; }
            public byte CelsValue { get; set; }
        }
        public const int size = 25;
        public Rectangle[,] Rectangles;

        public void FillField(ConsoleGraphics graphics)
        {
            int sizeX = graphics.ClientWidth / size;
            int sizeY = graphics.ClientHeight / size;
            Rectangles = new Rectangle[sizeX, sizeY];
            for (int i = 0; i < Rectangles.GetLength(0); i++)
            {
                for (int j = 0; j < Rectangles.GetLength(1); j++)
                {
                    Rectangles[i, j].CelsValue = 0;
                    Rectangles[i, j].Color = Color.DEfaultColoor;
                    Rectangles[i, j].x = j * size;
                    Rectangles[i, j].y = i * size;
                }
            }
        }

        public Field(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        //public override void Update(Field Field)
        //{
        //    ;
        //}
        //public override void Render(ConsoleGraphics graphics)
        //{
        //    foreach (var item in Rectangles)
        //    {
        //        graphics.FillRectangle((uint)item.Color, item.x,item.y, size, size);
        //    }
        //}
    }
}
